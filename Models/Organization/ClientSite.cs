using HRMS.Models.Common;
using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Organization
{
    public class ClientSite : BaseEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string SiteName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Client Client { get; set; }
        public ICollection<Employee> Employees { get; set; } // Employees deployed at this site
    }
}
