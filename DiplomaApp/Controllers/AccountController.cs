using AutoMapper;
using DiplomaApp.Models;
using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IRefugeeService refugeeService;
        private readonly IVolunteerService volunteerService;

        public AccountController(IUserService userService, IMapper mapper, IRefugeeService refugeeService,
            IVolunteerService volunteerService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.refugeeService = refugeeService;
            this.volunteerService = volunteerService;
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
                    if (await userService.IsUserExist(userDto))
                    {
                        if (!string.IsNullOrEmpty(userDto.Id))
                        {
                            if (model.RoleName.ToLower() == "volunteer")
                            {
                                volunteerService.Create(userDto);
                            }
                        }

                        return RedirectToAction("Index", "Home");
                    }
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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
            }

            return View(model);
        }

        [Route("/Account/Logout")]
        public async Task<IActionResult> Logout()
        {
            await userService.UserLogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
