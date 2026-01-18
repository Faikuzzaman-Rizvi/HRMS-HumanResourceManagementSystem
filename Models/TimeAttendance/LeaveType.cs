namespace HRMS.Models.TimeAttendance
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }
        public int DefaultDaysPerYear { get; set; }
        public bool AllowCarryForward { get; set; }
        public int MaxCarryForwardDays { get; set; }
        public bool AllowEncashment { get; set; }
        public bool RequiresApproval { get; set; }
        public int? MinDaysNotice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public ICollection<LeaveRule> LeaveRules { get; set; }
        public ICollection<LeaveBalance> LeaveBalances { get; set; }
    }
}
