using HRMS.Models.Common;
using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Organization
{
    public class ClientRequirement : BaseEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string RequirementCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DesignationId { get; set; }
        public int RequiredCount { get; set; }
        public DateTime RequiredDate { get; set; }
        public string Priority { get; set; } // High, Medium, Low
        public string Status { get; set; } // Open, In Progress, Fulfilled, Cancelled
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public Client Client { get; set; }
        public Designation Designation { get; set; }
    }
}
