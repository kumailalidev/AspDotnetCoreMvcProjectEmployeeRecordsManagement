using System;

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
    }
}
