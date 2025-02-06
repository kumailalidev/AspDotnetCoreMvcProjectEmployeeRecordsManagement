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
    }
}
