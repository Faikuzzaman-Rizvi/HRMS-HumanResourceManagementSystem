namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeBackgroundCheck
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public bool EducationVerified { get; set; }
        public bool ExperienceVerified { get; set; }
        public bool CriminalRecordCheck { get; set; }
        public bool ReferenceCheck { get; set; }
        public string VerificationAgency { get; set; }
        public DateTime? VerificationDate { get; set; }
        public string Status { get; set; } // Pending, Completed, Issues Found
        public string Remarks { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
