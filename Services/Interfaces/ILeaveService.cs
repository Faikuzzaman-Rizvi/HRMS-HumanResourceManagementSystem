using HRMS.DTOs.Common;
using HRMS.DTOs.TimeAttendance;

namespace HRMS.Services.Interfaces
{
    public interface ILeaveService
    {
        // Leave Type
        Task<ApiResponse<IEnumerable<LeaveTypeDTO>>> GetAllLeaveTypesAsync();
        Task<ApiResponse<LeaveTypeDTO>> GetLeaveTypeByIdAsync(int id);
        Task<ApiResponse<LeaveTypeDTO>> CreateLeaveTypeAsync(CreateLeaveTypeDTO dto, int createdBy);
        Task<ApiResponse<LeaveTypeDTO>> UpdateLeaveTypeAsync(int id, CreateLeaveTypeDTO dto, int updatedBy);
        Task<ApiResponse<bool>> DeleteLeaveTypeAsync(int id);

        // Leave Year
        Task<ApiResponse<IEnumerable<LeaveYearDTO>>> GetAllLeaveYearsAsync();
        Task<ApiResponse<LeaveYearDTO>> CreateLeaveYearAsync(CreateLeaveYearDTO dto, int createdBy);

        // Leave Balance
        Task<ApiResponse<IEnumerable<LeaveBalanceDTO>>> GetLeaveBalanceByEmployeeAsync(int employeeId, int leaveYearId);
        Task<ApiResponse<bool>> AllocateLeaveBalanceAsync(int leaveYearId, int createdBy);

        // Leave Application
        Task<ApiResponse<IEnumerable<LeaveApplicationDTO>>> GetAllApplicationsAsync(int? employeeId = null, string status = null);
        Task<ApiResponse<LeaveApplicationDTO>> GetApplicationByIdAsync(int id);
        Task<ApiResponse<LeaveApplicationDTO>> ApplyLeaveAsync(CreateLeaveApplicationDTO dto, int createdBy);
        Task<ApiResponse<LeaveApplicationDTO>> ApproveLeaveAsync(int id, ApproveLeaveDTO dto, int approverId);
        Task<ApiResponse<bool>> CancelLeaveAsync(int id, int cancelledBy);
    }
}