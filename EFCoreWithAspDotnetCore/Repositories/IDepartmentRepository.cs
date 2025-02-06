using System;

using EFCoreWithAspDotnetCore.Models;
using EFCoreWithAspDotnetCore.ViewModels;

namespace EFCoreWithAspDotnetCore.Repositories;

public interface IDepartmentRepository
{
    Task<Department> GetByIdAsync(int id);
    Task<List<DepartmentViewModel>> GetAllAsync();
    Task AddAsync(DepartmentViewModel department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(int id);
}
