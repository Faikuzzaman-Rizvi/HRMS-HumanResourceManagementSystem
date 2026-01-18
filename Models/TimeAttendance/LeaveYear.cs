namespace HRMS.Models.TimeAttendance
{
    public class LeaveYear
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsCurrent { get; set; }

        // Navigation
        public ICollection<LeaveBalance> LeaveBalances { get; set; }
    }
}
