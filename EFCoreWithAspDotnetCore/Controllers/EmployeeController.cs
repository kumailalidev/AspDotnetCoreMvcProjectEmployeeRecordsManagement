using System;

using EFCoreWithAspDotnetCore.Models;
using EFCoreWithAspDotnetCore.Repositories;
using EFCoreWithAspDotnetCore.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCoreWithAspDotnetCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            // Get all the employees from database
            List<EmployeeViewModel> employees = await _employeeRepository.GetAllAsync();

            // Filter employees by name
            string queryString = searchString.ToLower();
            if (!String.IsNullOrEmpty(queryString))
                employees = employees.Where(employee => employee.FirstName.ToLower().Contains(queryString) ||
                    employee.LastName.ToLower().Contains(queryString)).ToList();

            return View(employees);
        }

        // Handles HTTP GET method
        // GET Employee/Add
        public async Task<IActionResult> Add()
        {
            // Department data (from database)
            List<Department> departments = await _employeeRepository.GetAllDepartmentsAsync();

            // Assigning to ViewBag
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "Name");

            return View();
        }

        [HttpPost] // Handles HTTP POST method: POST Employee/Add
        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            if (!ModelState.IsValid) // Server-side validation
                return View(); // Return to Employee/Add with validation errors

            // Add employee to database
            await _employeeRepository.AddAsync(model);

            return RedirectToAction("Index", "Employee");
        }
    }
}
