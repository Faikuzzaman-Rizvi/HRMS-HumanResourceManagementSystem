using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRMS.Models.Organization
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CompanyId { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Industry { get; set; }
        public string Status { get; set; } // Active, Inactive, Prospect
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public Company Company { get; set; }
        public ICollection<ClientSite> ClientSites { get; set; }
        public ICollection<ClientRequirement> Requirements { get; set; }
        public ICollection<ClientRemark> Remarks { get; set; }
    }
}
