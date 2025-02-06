using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreWithAspDotnetCore.ViewModels
{
    // Contains properties specific to Department specific views.
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        public string Name { get; set; }
    }
}
