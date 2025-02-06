using System;

using EFCoreWithAspDotnetCore.Models;
using EFCoreWithAspDotnetCore.ViewModels;

namespace EFCoreWithAspDotnetCore.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(EmployeeViewModel employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);

        Task<List<Department>> GetAllDepartmentsAsync();
    }
}
