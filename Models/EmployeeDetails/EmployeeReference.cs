using HRMS.Models.Common;

namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeReference : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Organization { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
