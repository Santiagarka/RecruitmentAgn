using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using RecruitmentAgency.Core.Managers;
using RecruitmentAgency.Web.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentAgency.Core.Entities;

namespace RecruitmentAgency.Web.Controllers
{
    public class VacancyController : Controller
    {
        public enum SortState
        {
            NameAsc,
            NameDesc,
            CompanyNameAsc,
            CompanyNameDesc,
            TermAsc,
            TermDesc,
            SalaryAsc,
            SalaryDesc
        }

        private readonly IVacancyManager vacancyManager;
        private readonly IUserManager userManager;
        private readonly ISkillManager skillManager;
        private readonly ICandidateManager candidateManager;

        private readonly IMapper mapper;

        public VacancyController(IMapper mapper, IVacancyManager vacancyManager, IUserManager userManager, ISkillManager skillManager, ICandidateManager candidateManager)
        {
            this.mapper = mapper;
            this.vacancyManager = vacancyManager;
            this.userManager = userManager;
            this.skillManager = skillManager;
            this.candidateManager = candidateManager;
        }

        [Authorize(Roles = "Admin, HR, Employee")]
        public IActionResult Index(SortState sortOrder = SortState.NameAsc)
        {   
            
            var vacancies = mapper.Map<ICollection<VacancyViewModel>>(vacancyManager.GetAll());
            if(HttpContext.User.IsInRole("Employee"))
            {
                vacancies = vacancies.Where(v => v.CreatorId == userManager.GetByLogin(User.Identity.Name).Id).ToList();         
            }
            ViewData["NameSortParm"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["CompanySortParm"] = sortOrder == SortState.CompanyNameAsc ? SortState.CompanyNameDesc : SortState.CompanyNameAsc;
            ViewData["TermSortParm"] = sortOrder == SortState.TermAsc ? SortState.TermDesc : SortState.TermAsc;
            ViewData["SalarySortParm"] = sortOrder == SortState.SalaryAsc ? SortState.SalaryDesc : SortState.SalaryAsc;

            switch (sortOrder)
            {
                case SortState.NameAsc:
                    vacancies = vacancies.OrderBy(v => v.Name).ToList();
                    break;
                case SortState.NameDesc:
                    vacancies = vacancies.OrderByDescending(v => v.Name).ToList();
                    break;
                case SortState.CompanyNameAsc:
                    vacancies = vacancies.OrderBy(v => v.Company).ToList();
                    break;
                case SortState.CompanyNameDesc:
                    vacancies = vacancies.OrderByDescending(v => v.Company).ToList();
                    break;
                case SortState.TermAsc:
                    vacancies = vacancies.OrderBy(v => v.Term).ToList();
                    break;
                case SortState.TermDesc:
                    vacancies = vacancies.OrderByDescending(v => v.Term).ToList();
                    break;
                case SortState.SalaryAsc:
                    vacancies = vacancies.OrderBy(v => v.Salary).ToList();
                    break;
                case SortState.SalaryDesc:
                    vacancies = vacancies.OrderByDescending(v => v.Salary).ToList();
                    break;
                default:
                    vacancies = vacancies.OrderBy(v => v.Name).ToList();
                    break;
            }

            return View(vacancies);
        }

        [Authorize(Roles = "Employee")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(VacancyCreateModel.New);
        }

        [Authorize(Roles = "Employee")]
        [HttpPost]
        public IActionResult Create(VacancyCreateModel createModel)
        {
            var model = mapper.Map<Vacancy>(createModel);
            foreach (var item in createModel.SkillsId)
            {
                var skill = skillManager.Get(item);
                (model.Skills as List<Skill>).Add(skill);
            }
            model.Creator = userManager.GetByLogin(User.Identity.Name);
            vacancyManager.CreateProc(model);
            return RedirectToAction("Index", "Vacancy");
        }

        [Authorize(Roles = "Admin, HR, Employee, Jobseeker")]
        [HttpGet]
        public IActionResult View(int id)
        {
            var entity = mapper.Map<VacancyViewModel>(vacancyManager.Get(id));
            return View(entity);
        }

        [Authorize(Roles = "Employee")]
        public IActionResult SelectCandidates(int id)
        {
            var vacancy = vacancyManager.Get(id);
            if (vacancy == null)
            {
                return RedirectToAction("Index", "Candidate");
            }
            else
            {
                List<Candidate> candidates = new List<Candidate>();
                foreach (var skill in vacancy.Skills.Select(s => s.Id))
                {
                    candidates.AddRange(candidateManager.GetAll().Where(v => v.Salary >= vacancy.Salary && v.Skills.Select(s => s.Id).Contains(skill)));
                }

                var entity = mapper.Map<ICollection<CandidateViewModel>>(candidates);
                return View(entity);
            }
        }

        [Authorize(Roles = "Employee")]
        public IActionResult Lock(int id)
        {
            var entity = vacancyManager.Get(id);
            if (entity != null)
            {
                entity.IsActive = !entity.IsActive;
                vacancyManager.Update(entity);
            }
            
            return RedirectToAction("Index", "Vacancy");
        }
    }
}