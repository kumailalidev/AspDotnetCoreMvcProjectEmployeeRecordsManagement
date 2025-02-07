using System;

using EFCoreWithAspDotnetCore.Data;
using EFCoreWithAspDotnetCore.Models;
using EFCoreWithAspDotnetCore.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWithAspDotnetCore.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext; // Constructor dependency injection
        }

        public async Task AddAsync(EmployeeViewModel employee)
        {
            Employee newEmployee = new()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender,
                Email = employee.Email,
                Address = employee.Address,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId
                // Department is an navigation property therefore doesn't require to be set
            };
            await _dbContext.Employees.AddAsync(newEmployee);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            Employee employee = await _dbContext.Employees.FindAsync(Id);
            _dbContext.Employees.Remove(employee);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<EmployeeViewModel> GetAllAsync()
        {
            /**
              * IQueryable is suitable if you want to work with the data in deferred manner
                and apply additional filtering, sorting, or paging using LINQ before
                materializing the results.
            */
            var employees = _dbContext.Employees.Select(e => new EmployeeViewModel
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                DateOfBirth = e.DateOfBirth,
                PhoneNumber = e.PhoneNumber,
                Gender = e.Gender,
                Email = e.Email,
                Address = e.Address,
                IsActive = e.IsActive,
                DepartmentId = e.DepartmentId
                // Department is an navigation property therefore doesn't require to be set
            });

            return employees;
        }

        // public async Task<List<EmployeeViewModel>> GetAllAsync()
        // {
        //     List<Employee> employees = await _dbContext.Employees.ToListAsync();
        //     List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

        //     // Perform mapping
        //     foreach (var employee in employees)
        //     {
        //         var employeeViewModel = new EmployeeViewModel
        //         {
        //             EmployeeId = employee.EmployeeId,
        //             FirstName = employee.FirstName,
        //             LastName = employee.LastName,
        //             DateOfBirth = employee.DateOfBirth,
        //             PhoneNumber = employee.PhoneNumber,
        //             Gender = employee.Gender,
        //             Email = employee.Email,
        //             Address = employee.Address,
        //             IsActive = employee.IsActive,
        //             DepartmentId = employee.DepartmentId
        //             // Department is an navigation property therefore doesn't require to be set
        //         };

        //         // Add to list
        //         employeeViewModels.Add(employeeViewModel);
        //     }

        //     return employeeViewModels;
        // }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task UpdateAsync(Employee updatedEmployee)
        {
            var employee = await _dbContext.Employees.FindAsync(updatedEmployee.EmployeeId);
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Email = updatedEmployee.Email;
            employee.DateOfBirth = updatedEmployee.DateOfBirth;
            employee.PhoneNumber = updatedEmployee.PhoneNumber;
            employee.Address = updatedEmployee.Address;
            employee.DepartmentId = updatedEmployee.DepartmentId;
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAllDepartmentsAsync() =>
            // Using getting all the departments
            await _dbContext.Departments.ToListAsync();
    }
}
