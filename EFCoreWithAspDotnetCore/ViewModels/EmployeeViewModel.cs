using System;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)] // Makes sure it is date
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }

        //Relationship with Department

        [ForeignKey("Department")]
        public int DepartmentId { get; set; } //Foreign Key
        public Department? Department { get; set; } //Reference navigation property

    }
}
