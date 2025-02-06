using System;

using EFCoreWithAspDotnetCore.Repositories;
using EFCoreWithAspDotnetCore.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAspDotnetCore.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<DepartmentViewModel> departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost] // Handles HTTP POST method
        public async Task<IActionResult> Add(DepartmentViewModel model)
        {
            if (!ModelState.IsValid) // Server-side validation
                return View(model); // Return to view with validation errors

            // Insert data to database
            await _departmentRepository.AddAsync(model);

            // Redirect to index view
            return RedirectToAction("Index", "Department");
        }
    }
}
