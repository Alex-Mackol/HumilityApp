using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        [Route("Identity/Account/Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
