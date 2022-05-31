using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Controllers
{
    //[Route("/Apartament")]
    public class ApartamentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
