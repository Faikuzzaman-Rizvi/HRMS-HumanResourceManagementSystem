using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.TimeAttendance
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int? ShiftId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string Status { get; set; } // Present, Absent, Late, Half Day, On Leave, Holiday, Weekend
        public decimal WorkingHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public bool IsManualEntry { get; set; }
        public string Remarks { get; set; }
        public int? ProcessId { get; set; }
        public DateTime? ProcessedDate { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public Shift Shift { get; set; }
        public AttendanceProcess Process { get; set; }
    }
}
