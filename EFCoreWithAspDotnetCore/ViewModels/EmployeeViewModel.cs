using System;
using System.ComponentModel.DataAnnotations.Schema;

using EFCoreWithAspDotnetCore.Models;

namespace EFCoreWithAspDotnetCore.ViewModels
{
    // Contains properties specific to Employee specific views.
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
        }
        public int EmployeeId { get; set; } // EF Core assumes Id or {ClassName}Id as PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        //Relationship with Department

        [ForeignKey("Department")]
        public int DepartmentId { get; set; } //Foreign Key
        public Department? Department { get; set; } //Reference navigation property

    }
}
