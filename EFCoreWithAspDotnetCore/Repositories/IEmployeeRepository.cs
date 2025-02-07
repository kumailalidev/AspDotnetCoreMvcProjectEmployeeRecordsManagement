using System;

using EFCoreWithAspDotnetCore.Models;
using EFCoreWithAspDotnetCore.ViewModels;

namespace EFCoreWithAspDotnetCore.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeViewModel> GetByIdAsync(int id);
        // Task<List<EmployeeViewModel>> GetAllAsync();
        IQueryable<EmployeeViewModel> GetAllAsync();
        Task AddAsync(EmployeeViewModel employee);
        Task UpdateAsync(EmployeeViewModel employee);
        Task DeleteAsync(int id);

        Task<List<Department>> GetAllDepartmentsAsync();
    }
}
