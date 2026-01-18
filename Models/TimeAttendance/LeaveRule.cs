using HRMS.Models.EmployeeDetails;
using HRMS.Models.Organization;

namespace HRMS.Models.TimeAttendance
{
    public class LeaveRule
    {
        public int Id { get; set; }
        public int LeaveTypeId { get; set; }
        public int? DesignationId { get; set; }
        public int? GradeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? LocationId { get; set; }
        public int AllocatedDays { get; set; }
        public bool AllowCarryForward { get; set; }
        public int MaxCarryForwardDays { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

        // Navigation
        public LeaveType LeaveType { get; set; }
        public Designation Designation { get; set; }
        public Grade Grade { get; set; }
        public Department Department { get; set; }
        public Location Location { get; set; }
    }
}
