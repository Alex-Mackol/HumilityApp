using DiplomaApp.Areas.Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (model == null)
            {
                return View("Error");
            }

            return View();
        }
    }
}
