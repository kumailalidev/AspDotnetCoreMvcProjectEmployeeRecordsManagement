using System;

using EFCoreWithAspDotnetCore.Models;

using Microsoft.EntityFrameworkCore;

namespace EFCoreWithAspDotnetCore.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions options) : base(options)
        {
            // Take a single parameter 'options' of type DbContextOptions which provides
            // configuration options for DbContext class
        }

        // DbSet, a class that represents a entity set in a database. Allows to perform
        // Querying, Inserting, Updating, Deleting, etc database operations.
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
