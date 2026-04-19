using HRMS.DTOs.Common;
using HRMS.DTOs.TimeAttendance;

namespace HRMS.Services.Interfaces
{
    public interface IAttendanceService
    {
        // Shift
        Task<ApiResponse<IEnumerable<ShiftDTO>>> GetAllShiftsAsync();
        Task<ApiResponse<ShiftDTO>> GetShiftByIdAsync(int id);
        Task<ApiResponse<ShiftDTO>> CreateShiftAsync(CreateShiftDTO dto, int createdBy);
        Task<ApiResponse<ShiftDTO>> UpdateShiftAsync(int id, CreateShiftDTO dto, int updatedBy);

        // Shift Assignment
        Task<ApiResponse<ShiftAssignmentDTO>> AssignShiftAsync(CreateShiftAssignmentDTO dto, int createdBy);
        Task<ApiResponse<ShiftAssignmentDTO>> GetCurrentShiftByEmployeeAsync(int employeeId);

        // Attendance
        Task<ApiResponse<IEnumerable<AttendanceDTO>>> GetAttendanceByEmployeeAsync(int employeeId, int month, int year);
        Task<ApiResponse<AttendanceSummaryDTO>> GetAttendanceSummaryAsync(int employeeId, int month, int year);
        Task<ApiResponse<IEnumerable<AttendanceSummaryDTO>>> GetMonthlyAttendanceSummaryAsync(int month, int year, int? departmentId = null);

        // Manual Attendance
        Task<ApiResponse<AttendanceDTO>> CreateManualAttendanceAsync(CreateManualAttendanceDTO dto, int createdBy);
        Task<ApiResponse<bool>> ApproveManualAttendanceAsync(int id, ApproveManualAttendanceDTO dto, int approverId);

        // Holiday
        Task<ApiResponse<IEnumerable<HolidayDTO>>> GetHolidaysAsync(int year, int? locationId = null);
        Task<ApiResponse<HolidayDTO>> CreateHolidayAsync(CreateHolidayDTO dto, int createdBy);
        Task<ApiResponse<bool>> DeleteHolidayAsync(int id);
    }
}