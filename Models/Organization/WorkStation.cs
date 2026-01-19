using HRMS.Models.Common;
using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Organization
{
    public class WorkStation : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Location Location { get; set; }
        public Department Department { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
