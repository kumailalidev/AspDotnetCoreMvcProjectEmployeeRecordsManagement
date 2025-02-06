using System;

using EFCoreWithAspDotnetCore.Data;
using EFCoreWithAspDotnetCore.Models;
using EFCoreWithAspDotnetCore.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace EFCoreWithAspDotnetCore.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;

        //Dependency Injection
        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            List<Department> departments = await _dbContext.Departments.ToListAsync();
            List<DepartmentViewModel> departmentViewModels = new List<DepartmentViewModel>();

            foreach (Department department in departments)
            {
                DepartmentViewModel departmentViewModel = new DepartmentViewModel
                {
                    DepartmentId = department.DepartmentId,
                    Name = department.Name
                };

                departmentViewModels.Add(departmentViewModel);
            }

            return departmentViewModels;
        }

        public async Task AddAsync(DepartmentViewModel department)
        {
            var newDepartment = new Department()
            {
                Name = department.Name
            };

            await _dbContext.Departments.AddAsync(newDepartment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department updatedDepartment)
        {

            var department = await _dbContext.Departments.FindAsync(updatedDepartment.DepartmentId);
            department.Name = updatedDepartment.Name;

            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Department department = await _dbContext.Departments.FindAsync(id);
            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}
