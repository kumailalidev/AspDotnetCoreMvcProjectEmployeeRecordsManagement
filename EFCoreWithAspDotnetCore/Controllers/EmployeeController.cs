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

        // Handles HTTP GET method: GET Employee/Add
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost] // Handles HTTP POST method: POST Employee/Add
        public IActionResult Add(string firstName, string lastName)
        // Parameter names are same as the value of attribute 'name' of input field
        // Case insensitive
        {
            return View();
        }
    }
}
