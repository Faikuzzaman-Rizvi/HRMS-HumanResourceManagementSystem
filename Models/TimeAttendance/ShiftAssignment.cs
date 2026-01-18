using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.TimeAttendance
{
    public class ShiftAssignment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public bool IsActive { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public Shift Shift { get; set; }
    }
}
