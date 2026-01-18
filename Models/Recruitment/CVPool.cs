using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Recruitment
{
    public class CVPool
    {
        public int Id { get; set; }
        public string CandidateName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? DesignationId { get; set; }
        public int ExperienceYears { get; set; }
        public string CurrentCompany { get; set; }
        public decimal? ExpectedSalary { get; set; }
        public string CVFileUrl { get; set; }
        public string Source { get; set; } // Job Portal, Reference, Walk-in
        public string Status { get; set; } // New, Shortlisted, Interviewed, Selected, Rejected, On Hold
        public DateTime ReceivedDate { get; set; }
        public string Skills { get; set; }
        public string Remarks { get; set; }

        // Navigation
        public Designation Designation { get; set; }
    }
}
