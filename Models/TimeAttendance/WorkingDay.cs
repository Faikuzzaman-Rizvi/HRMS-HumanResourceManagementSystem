using HRMS.Models.Organization;

namespace HRMS.Models.TimeAttendance
{
    public class WorkingDay
    {
        public int Id { get; set; }
        public int? LocationId { get; set; }
        public int? DepartmentId { get; set; }
        public string DayOfWeek { get; set; } // Monday, Tuesday etc.
        public bool IsWorkingDay { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        // Navigation
        public Location Location { get; set; }
        public Department Department { get; set; }
    }
}
