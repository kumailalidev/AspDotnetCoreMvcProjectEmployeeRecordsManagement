using System;

using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAspDotnetCore.Controllers
{
    public class EmployeeController : Controller
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
        public IActionResult Add(string firstName, string lastName)
        // Parameter names are same as the value of attribute 'name' of input field
        // Case insensitive
        {
            return View();
        }
    }
}
