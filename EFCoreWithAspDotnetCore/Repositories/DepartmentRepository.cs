using System;

using EFCoreWithAspDotnetCore.Data;
using EFCoreWithAspDotnetCore.Models;

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

        public async Task<List<Department>> GetAllAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task AddAsync(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
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
