using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Managers;
using RecruitmentAgency.Web.Models.Account;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecruitmentAgency.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;

        public AccountController(IUserManager userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        /// <summary>
        /// Получить страницу логина
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            return View(LoginModel.New);
        }

        /// <summary>
        /// Выполнить логин пользователя
        /// </summary>
        /// <param name="model">Данные для логина</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = userManager.Get(model.Login, model.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Некорректные логин и(или) пароль");
                return View(model);
            }

            await Authenticate(user);

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Получить страницу регистрации
        /// </summary>
        [HttpGet]
        public IActionResult Register()
        {
            return View(RegisterModel.New);
        }

        /// <summary>
        /// Выполнить регистрацию нового пользователя
        /// </summary>
        /// <param name="model">Данные для регистрации</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var isFree = userManager.FreeLogin(model.Login);
            if (isFree)
            {
                var createUser = mapper.Map<User>(model);
                var newUser = userManager.Create(createUser);

                await Authenticate(newUser);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Такой пользователь существует");
                return View(model);
            }
        }

        /// <summary>
        /// Выполнить выход из системы
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// Получить страницу с отказом в доступе
        /// </summary>
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }


        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role != null ? user.Role.Name : string.Empty)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}