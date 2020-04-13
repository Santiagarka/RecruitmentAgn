using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.Core.Managers;
using RecruitmentAgency.Web.Models;
using System.Collections.Generic;

namespace RecruitmentAgency.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly IUserManager userManager;
        private readonly IRoleManager roleManager;
        private readonly IMapper mapper;

        public UserController(IUserManager userManager, IRoleManager roleManager, IMapper mapper)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        
        public IActionResult Index()
        {
            var users = mapper.Map<ICollection<UserModel>>(userManager.GetAll());
            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userEdit = userManager.Get(id);
            var model = mapper.Map<UserEditModel>(userEdit);
            if (userEdit.Role != null)
            {
                model.RoleId = userEdit.Role.Id;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserEditModel model)
        {
            var userEdit = userManager.Get(model.Id);
            userEdit.Email = model.Email;
            userEdit.Role = model.RoleId.HasValue ? roleManager.Get(model.RoleId.Value) : null;

            userManager.Update(userEdit);
            return RedirectToAction("Index", "User");
        }
    }
}