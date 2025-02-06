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
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            // Get all the employees from database
            List<EmployeeViewModel> employees = await _employeeRepository.GetAllAsync();

            // Filter employees by name
            if (!String.IsNullOrEmpty(searchString))
            {
                string queryString = searchString.ToLower();
                employees = employees.Where(employee => employee.FirstName.ToLower().Contains(queryString) ||
                    employee.LastName.ToLower().Contains(queryString)).ToList();

            }

            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateOfBirthSortParam"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewData["IsActiveSortParam"] = sortOrder == "isactive_asc" ? "isactive_desc" : "isactive_asc";

            switch (sortOrder)
            {
                case "name_desc":
                    // Sort employees by FirstName in descending order
                    employees = employees.OrderByDescending(employee => employee.FirstName).ToList();
                    break;
                case "date_asc":
                    // Sort employees by DOB in ascending order
                    employees = employees.OrderBy(employee => employee.DateOfBirth).ToList();
                    break;
                case "date_desc":
                    // Sort employees by DOB in descending order
                    employees = employees.OrderByDescending(employee => employee.DateOfBirth).ToList();
                    break;
                case "isactive_desc":
                    // Sort employees by IsActive in descending order
                    employees = employees.OrderByDescending(employee => employee.IsActive).ToList();
                    break;
                case "isactive_asc":
                    // Sort employees by IsActive ascending order
                    employees = employees.OrderBy(employee => employee.IsActive).ToList();
                    break;
                default:
                    // Sort employees by FirstName in ascending order
                    employees = employees.OrderBy(employee => employee.FirstName).ToList();
                    break;
            }

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
