namespace HRMS.DTOs.TimeAttendance
{
    // ─── Leave Type ──────────────────────
    public class LeaveTypeDTO
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
    }

    public class CreateLeaveTypeDTO
    {
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
    }

    // ─── Leave Year ───────────────────────────
    public class LeaveYearDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsCurrent { get; set; }
    }

    public class CreateLeaveYearDTO
    {
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrent { get; set; }
    }

    // ─── Leave Balance ────────────────────────
    public class LeaveBalanceDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }
        public int LeaveYearId { get; set; }
        public int LeaveYear { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal AllocatedDays { get; set; }
        public decimal CarryForwardDays { get; set; }
        public decimal UsedDays { get; set; }
        public decimal RemainingDays { get; set; }
        public decimal EncashedDays { get; set; }
    }

    // ─── Leave Application ────────────────────
    public class LeaveApplicationDTO
    {
        public int Id { get; set; }
        public string LeaveCode { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal TotalDays { get; set; }
        public string Reason { get; set; }
        public string ContactDuringLeave { get; set; }
        public string Status { get; set; }
        public string ApproverName { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApproverComments { get; set; }
        public DateTime ApplicationDate { get; set; }
    }

    public class CreateLeaveApplicationDTO
    {
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Reason { get; set; }
        public string ContactDuringLeave { get; set; }
    }

    public class ApproveLeaveDTO
    {
        public string Status { get; set; } // Approved, Rejected
        public string Comments { get; set; }
    }

    // ─── Shift ────────────────────────────────
    public class ShiftDTO
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
        public TimeSpan GraceTime { get; set; }
        public bool IsNightShift { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateShiftDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal WorkingHours { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public decimal? BreakHours { get; set; }
        public TimeSpan GraceTime { get; set; }
        public bool IsNightShift { get; set; }
    }

    public class ShiftAssignmentDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateShiftAssignmentDTO
    {
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }

    // ─── Attendance ───────────────────────────
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime Date { get; set; }
        public string ShiftName { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string Status { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public bool IsManualEntry { get; set; }
        public string Remarks { get; set; }
    }

    public class CreateManualAttendanceDTO
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string Reason { get; set; }
    }

    public class ApproveManualAttendanceDTO
    {
        public string Status { get; set; } // Approved, Rejected
    }

    public class AttendanceSummaryDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalWorkingDays { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int LateDays { get; set; }
        public int HalfDays { get; set; }
        public int LeaveDays { get; set; }
        public int HolidayDays { get; set; }
        public decimal TotalWorkingHours { get; set; }
        public decimal TotalOvertimeHours { get; set; }
    }

    // ─── Holiday ──────────────────────────────
    public class HolidayDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateHolidayDTO
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? LocationId { get; set; }
    }
}