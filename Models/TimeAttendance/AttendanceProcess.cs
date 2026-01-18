namespace HRMS.Models.TimeAttendance
{
    public class AttendanceProcess
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime ProcessDate { get; set; }
        public string Status { get; set; } // In Progress, Completed
        public int TotalEmployees { get; set; }
        public int ProcessedEmployees { get; set; }
        public int ProcessedBy { get; set; }

        // Navigation
        public ICollection<Attendance> Attendances { get; set; }
    }
}
