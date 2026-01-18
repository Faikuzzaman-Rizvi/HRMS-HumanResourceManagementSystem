using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.TimeAttendance
{
    public class LeaveApplication
    {
        public int Id { get; set; }
        public string LeaveCode { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal TotalDays { get; set; }
        public string Reason { get; set; }
        public string ContactDuringLeave { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected, Cancelled
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApproverComments { get; set; }
        public DateTime ApplicationDate { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public LeaveType LeaveType { get; set; }
        public Employee Approver { get; set; }
    }
}
