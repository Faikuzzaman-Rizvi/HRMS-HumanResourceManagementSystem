using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Training
{
    public class TrainingAttendance
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public string Remarks { get; set; }
        // Navigation
        public Training Training { get; set; }
        public Employee Employee { get; set; }
    }
}
