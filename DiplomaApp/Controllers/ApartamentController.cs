using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DiplomaApp.Data.Enum;
using DiplomaApp.Models.ApartamentViewModels;
using DiplomaApp.Services.Interfaces;
using DiplomaApp.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiplomaApp.Controllers
{
    public class ApartamentController : Controller
    {
        private readonly TypeOfHouse typeOfHouse;
        private readonly IApartamentService apartamentService;
        private readonly IUserService userService;
        private readonly IVolunteerService volunteerService;
        private readonly IMapper mapper;

        public ApartamentController(IApartamentService apartamentService, IUserService userService,
            IMapper mapper, IVolunteerService volunteerService)
        {
            this.userService = userService;
            this.apartamentService = apartamentService;
            this.mapper = mapper;
            typeOfHouse = new TypeOfHouse();
            this.volunteerService = volunteerService;
        }

        public async Task<IActionResult> Index(bool myposts)
        {
            GetTypeSelectLists();
            string userName = HttpContext.User.Identity.Name;
            UserDto user = null;
            if (userName != null)
            { 
                user = await userService.GetUser(userName);
                ViewBag.Volunteer = user;
            }

            IEnumerable<ApartamentDto> apartamentsDto = null;
            if (myposts && user != null)
            {
                var volunteerDto = volunteerService.GetVolunteer(user.Id);
                apartamentsDto = apartamentService.GetAparatments(volunteerDto.Id);
                ViewBag.EnableEdit = true;
            }
            else
            {
                apartamentsDto = apartamentService.GetAparatments();
                ViewBag.EnableEdit = false;
            }

            if (apartamentsDto != null)
            {
                return View(apartamentsDto);
            }
            else
            {
                return View();
            }
        }

        [Route("/Apartament/Create")]
        [HttpPost]
        public async Task<JsonResult> Create(ApartamentCreateViewModel model)
        {
            try
            {
                var apartamentDto = mapper.Map<ApartamentDto>(model);
                string userName = HttpContext.User.Identity.Name;
                if (userName == null)
                {
                    throw new ArgumentException("Юзер не зареєстрован!");
                }

                var userDto = await userService.GetUser(userName);
                var volunteerDto = volunteerService.GetVolunteer(userDto.Id);

                apartamentDto.VolunteerId = volunteerDto.Id;
                apartamentDto.VolunteerPhone = volunteerDto.PhoneNumber;
                apartamentDto.VolunterName = volunteerDto.Name;
                apartamentService.CreateApart(apartamentDto);
                
                return Json(new { Succeed = true, Message = "ok" });

            }
            catch (ArgumentException ex)
            {
                return Json(new { Succeed = false, Message = ex.Message });
            }
        }

        [Route("/Apartament/Delete")]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var deletedApart = apartamentService.Delete(id);
                return Json(new { Succeed = true, Message = "ok" });

            }
            catch (ArgumentException ex)
            {
                return Json(new { Succeed = false, Message = ex.Message });
            }
        }

        private void GetTypeSelectLists()
        {
            var typeList = GetTypeHelpDisplayNames();
            var typeSelectList = new SelectList(typeList);
            ViewData["TypeList"] = typeSelectList;
        }

        private List<string> GetTypeHelpDisplayNames()
        {
            var type = typeOfHouse.GetType();
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
