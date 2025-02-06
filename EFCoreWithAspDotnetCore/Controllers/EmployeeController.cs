using System;

using EFCoreWithAspDotnetCore.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAspDotnetCore.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Handles HTTP GET method: GET Employee/Add
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost] // Handles HTTP POST method: POST Employee/Add
        public IActionResult Add(EmployeeViewModel model)
        {
            return View();
        }
    }
}
