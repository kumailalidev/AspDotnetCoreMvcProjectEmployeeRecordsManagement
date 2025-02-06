using System;

namespace EFCoreWithAspDotnetCore.Models
{
    public class Department
    {
        public int DepartmentId { get; set; } // EF Core assumes Id or {ClassName}Id as PK and is automatically generated
        public string Name { get; set; }

        // Relationship with Employees
        public ICollection<Employee> Employees { get; set; }
        // Collection navigation property signifies that a single Department can be
        // associated with multiple Employee entities. It's a way to define a
        //one-to-many relationship.
    }
}
