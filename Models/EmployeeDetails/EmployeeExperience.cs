using HRMS.Models.Common;

namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeExperience : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsCurrentJob { get; set; }
        public string JobResponsibilities { get; set; }
        public string ReasonForLeaving { get; set; }
        public decimal? LastSalary { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
