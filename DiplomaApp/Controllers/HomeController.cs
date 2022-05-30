using DiplomaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DiplomaApp.Services.Interfaces;
using MakeUpShop.SeedData;

namespace DiplomaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IServiceProvider serviceProvider;
        private IRoleService roleService;

        public HomeController(IServiceProvider serviceProvider, ILogger<HomeController> logger, IRoleService roleService)
        {
            _logger = logger;
            this.serviceProvider = serviceProvider;
            this.roleService = roleService;
        }

        public IActionResult Index()
        {
            //SeedData.ScriptToCreateIdentityDBAsync(serviceProvider, roleService);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}