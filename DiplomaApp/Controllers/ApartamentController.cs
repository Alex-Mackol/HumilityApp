﻿using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Controllers
{
    public class ApartamentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}