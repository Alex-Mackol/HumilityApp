using DiplomaApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Controllers
{
    //[Route("/Apartament")]
    public class ApartamentController : Controller
    {
        private readonly IApartamentService appartamentService;
        private readonly IUserService userService;

        public ApartamentController(IApartamentService appartamentService, IUserService userService)
        {
            this.userService = userService;
            this.appartamentService = appartamentService;
        }
        public async Task<IActionResult> Index()
        {
            var apartamentsDto = appartamentService.GetAparatments();
            string userName = HttpContext.User.Identity.Name;
            var user = await userService.GetUser(userName);

            ViewBag.Volunteer = user;

            return View(apartamentsDto);
        }
    }
}
