using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Managers;
using RecruitmentAgency.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System;

namespace RecruitmentAgency.Web.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateManager candidateManager;
        private readonly IVacancyManager vacancyManager;
        private readonly IUserManager userManager;
        private readonly ISkillManager skillManager;
        private readonly IWebHostEnvironment appEnvironment;

        private readonly IMapper mapper;

        public CandidateController(IMapper mapper, ICandidateManager candidateManager, IVacancyManager vacancyManager, IUserManager userManager, ISkillManager skillManager, IWebHostEnvironment appEnvironment)
        {
            this.mapper = mapper;
            this.candidateManager = candidateManager;
            this.vacancyManager = vacancyManager;
            this.userManager = userManager;
            this.skillManager = skillManager;
            this.appEnvironment = appEnvironment;
        }

        [Authorize(Roles = "Admin, HR, Employee")]
        public IActionResult Index()
        {
            var candidates = mapper.Map<ICollection<CandidateViewModel>>(candidateManager.GetAll());
            return View(candidates);
        }

        [Authorize(Roles = "Jobseeker")]
        [HttpGet]
        public IActionResult CreateOrUpdate()
        {
            var candidate = candidateManager.GetAll().FirstOrDefault(v => v.Creator.Id == userManager.GetByLogin(User.Identity.Name).Id);
            CandidateCreateModel entity;
            if (candidate == null)
            {
                entity = CandidateCreateModel.New;
            }
            else
            {
                entity = mapper.Map<CandidateCreateModel>(candidate);
                entity.SkillsId = candidate.Skills.Select(s => s.Id);
            }
            return View(entity);
        }

        [Authorize(Roles = "Jobseeker")]
        [HttpPost]
        public IActionResult CreateOrUpdate(CandidateCreateModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Foto != null)
                {
                    var uniqueFileName = GetUniqueFileName(model.Foto.FileName);
                    var uploads = Path.Combine(appEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    model.Foto.CopyTo(new FileStream(filePath, FileMode.Create));
                    model.FotoURL = filePath;
                }

                var entity = mapper.Map<Candidate>(model);
                foreach (var item in model.SkillsId)
                {
                    var skill = skillManager.Get(item);
                    (entity.Skills as List<Skill>).Add(skill);
                }
                entity.Creator = userManager.GetByLogin(User.Identity.Name);
                if (entity.Id == 0)
                {
                    candidateManager.Create(entity);
                }
                else
                {
                    candidateManager.Update(entity);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin, HR, Employee, Jobseeker")]
        public IActionResult View(int id)
        {
            var candidate = candidateManager.Get(id);
            var entity = mapper.Map<CandidateViewModel>(candidate);
            return View(entity);
        }

        [Authorize(Roles = "Jobseeker")]
        public IActionResult SelectVacancies()
        {
            var candidate = candidateManager.GetAll().FirstOrDefault(v => v.Creator.Id == userManager.GetByLogin(User.Identity.Name).Id);
            if (candidate == null)
            {
                return RedirectToAction("CreateOrUpdate", "Candidate");
            }
            else
            {
                List<Vacancy> vacancies = new List<Vacancy>();
                foreach (var skill in candidate.Skills.Select(s=>s.Id))
                {
                    vacancies.AddRange(vacancyManager.GetAll().Where(v => v.Salary >= candidate.Salary && v.Skills.Select(s => s.Id).Contains(skill) && v.IsActive && v.Term <= DateTime.Now));
                }

                var entity = mapper.Map<ICollection<VacancyViewModel>>(vacancies);
                return View(entity);
            }
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}