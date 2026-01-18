using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.TimeAttendance
{
    public class ManualAttendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string Reason { get; set; }
        public int EnteredBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected

        // Navigation
        public Employee Employee { get; set; }
    }
}
