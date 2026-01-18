namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeDocument
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string DocumentType { get; set; } // Resume, Certificate, NID, Passport, Photo
        public string DocumentName { get; set; }
        public string DocumentUrl { get; set; }
        public DateTime UploadedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
