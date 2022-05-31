using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DiplomaApp.Data.Enum;
using DiplomaApp.Models.HelpRefugeeModels;
using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace DiplomaApp.Controllers
{
    // [Authorize(Roles = "refugee")]
    public class HelpController : Controller
    {
        private readonly TypeOfHelp typeOfHelp;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IRefugeeService refugeeService;

        public HelpController(IMapper mapper, IUserService userService, IRefugeeService refugeeService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.refugeeService = refugeeService;
            typeOfHelp = new TypeOfHelp();
        }
        public IActionResult HelpIndex()
        {
            GetTypeSelectLists();
            ViewBag.User = HttpContext.User.Identity.Name;
            return View();
        }

        [Route("/Help/RegisterHelp")]
        public async Task<JsonResult> RegisterHelp(RegisterHelpRefViewModel model)
        {
            var refugeeDto = mapper.Map<RefugeesDto>(model);
            string userName = HttpContext.User.Identity.Name;
            var userDto = await userService.GetUser(userName);

            refugeeDto.UserId = userDto.Id;
            refugeeService.Update(refugeeDto, userDto);

            return Json(new { Success = true, Message = "Ваш запит відправлено! З'явіться в пункт допомоги!"});
        }

        private void GetTypeSelectLists()
        {
            var typeList = GetTypeHelpDisplayNames();
            //var typeSelectList = new SelectList(typeList);
            ViewBag.TypeList = typeList;
        }
        private List<string> GetTypeHelpDisplayNames()
        {
            var type = typeOfHelp.GetType();
            var displaynames = new List<string>();
            var names = Enum.GetNames(type);
            foreach (var name in names)
            {
                var field = type.GetField(name);
                var fds = field.GetCustomAttributes(typeof(DisplayAttribute), true);

                if (fds.Length == 0)
                {
                    displaynames.Add(name);
                }

                foreach (DisplayAttribute fd in fds)
                {
                    displaynames.Add(fd.Name);
                }
            }
            return displaynames;
        }
    }
}
