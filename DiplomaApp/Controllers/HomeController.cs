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
        private IProductService productService;
        private ICategoryService categoryService;

        public HomeController(IServiceProvider serviceProvider, ILogger<HomeController> logger, 
            IRoleService roleService, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            this.serviceProvider = serviceProvider;
            this.roleService = roleService;
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Index(string category)
        {
            //SeedData.ScriptToCreateIdentityDBAsync(serviceProvider, roleService);
            //SeedData.ScriptToCreateDBData(serviceProvider);
            ViewBag.Products = productService.GetProducts();
            ViewBag.Categories = categoryService.GetCategories();
            ViewBag.CurrentCategory = string.IsNullOrEmpty(category) ? "Всі товари" : category;
            return View();
        }

        public IActionResult Details()
        {
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