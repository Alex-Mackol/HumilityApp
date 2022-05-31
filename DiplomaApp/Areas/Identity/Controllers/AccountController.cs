using AutoMapper;
using DiplomaApp.Areas.Identity.Models;
using DiplomaApp.Models;
using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = mapper.Map<UserDto>(model);
                if (await userService.IsUserCreated(userDto, model.Password))
                {
                    //Todo: create volunteer or refugee
                    return RedirectToAction("Index", "Home", new {area = ""});
                }
                else
                {
                    foreach (var error in userService.ErrorsCollection)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            return View(new LoginViewModel {ReturnUrl = (returnUrl != null ? returnUrl : nameof(returnUrl))});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = mapper.Map<UserDto>(model);
                if (await userService.IsUserExist(userDto))
                {
                    return RedirectToAction("Index", "Home", new {area = ""});
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
            }

            return View(model);
        }

        [Route("/Identity/Account/Logout")]
        public async Task<IActionResult> Logout()
        {
            await userService.UserLogOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
