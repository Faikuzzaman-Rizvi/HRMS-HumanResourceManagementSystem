using HRMS.Models.Common;
using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Organization
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CompanyId { get; set; }
        public int? LocationId { get; set; }
        public int? ParentDepartmentId { get; set; } // For hierarchy
        public int? ManagerEmployeeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public Company Company { get; set; }
        public Location Location { get; set; }
        public Department ParentDepartment { get; set; }
        public ICollection<Department> SubDepartments { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<WorkStation> WorkStations { get; set; }
    }
}
