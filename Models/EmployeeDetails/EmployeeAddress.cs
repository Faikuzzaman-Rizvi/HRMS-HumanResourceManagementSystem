using HRMS.Models.Common;

namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeAddress : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string AddressType { get; set; } // Present, Permanent
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public bool IsPrimary { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
