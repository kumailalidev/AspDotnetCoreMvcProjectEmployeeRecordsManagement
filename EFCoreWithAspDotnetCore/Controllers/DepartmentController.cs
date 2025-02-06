using System;

using EFCoreWithAspDotnetCore.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAspDotnetCore.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost] // Handles HTTP POST method
        public IActionResult Add(DepartmentViewModel model)
        {
            if (!ModelState.IsValid) // Server-side validation
                return View(model); // Return to view with validation errors

            return View();
        }
    }
}
