using HRMS.Models.Common;

namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeEducation : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Degree { get; set; }
        public string Major { get; set; }
        public string Institution { get; set; }
        public string Board { get; set; }
        public string Country { get; set; }
        public int PassingYear { get; set; }
        public string Result { get; set; } // CGPA/Grade
        public string CertificateUrl { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
