using System;

using EFCoreWithAspDotnetCore.Models;
using EFCoreWithAspDotnetCore.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            // Department data (in-memory)
            List<Department> departments = new List<Department>
            {
                new Department {DepartmentId = 1, Name = "IT"},
                new Department {DepartmentId = 1, Name = "HR"}
            };

            // Assigning to ViewBag
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            return View();
        }

        [HttpPost] // Handles HTTP POST method: POST Employee/Add
        public IActionResult Add(EmployeeViewModel model)
        {
            return View();
        }
    }
}
