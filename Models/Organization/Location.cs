using HRMS.Models.Common;
using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Organization
{
    public class Location : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CompanyId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public bool IsHeadOffice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public Company Company { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<WorkStation> WorkStations { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
