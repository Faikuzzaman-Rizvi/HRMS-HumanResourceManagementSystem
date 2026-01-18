using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.TimeAttendance
{
    public class LeaveBalance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int LeaveYearId { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal AllocatedDays { get; set; }
        public decimal CarryForwardDays { get; set; }
        public decimal UsedDays { get; set; }
        public decimal RemainingDays { get; set; }
        public decimal EncashedDays { get; set; }
        public DateTime LastUpdated { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public LeaveType LeaveType { get; set; }
        public LeaveYear LeaveYear { get; set; }
    }
}
