namespace HRMS.Models.TimeAttendance
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal WorkingHours { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public decimal? BreakHours { get; set; }
        public TimeSpan GraceTime { get; set; } // Late coming grace
        public bool IsNightShift { get; set; }
        public bool IsActive { get; set; }

        // Navigation
        public ICollection<ShiftAssignment> ShiftAssignments { get; set; }
    }
}
