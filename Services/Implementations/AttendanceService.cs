using AutoMapper;
using HRMS.DTOs.Common;
using HRMS.DTOs.TimeAttendance;
using HRMS.Models.TimeAttendance;
using HRMS.Repositories.Interfaces;
using HRMS.Services.Interfaces;

namespace HRMS.Services.Implementations
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AttendanceService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ShiftDTO>>> GetAllShiftsAsync()
        {
            try
            {
                var shifts = await _uow.Shifts.FindAsync(s => s.IsActive);
                return ApiResponse<IEnumerable<ShiftDTO>>.SuccessResponse(_mapper.Map<IEnumerable<ShiftDTO>>(shifts));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<ShiftDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<ShiftDTO>> GetShiftByIdAsync(int id)
        {
            try
            {
                var shift = await _uow.Shifts.GetByIdAsync(id);
                if (shift == null || !shift.IsActive) return ApiResponse<ShiftDTO>.ErrorResponse("Shift not found");
                return ApiResponse<ShiftDTO>.SuccessResponse(_mapper.Map<ShiftDTO>(shift));
            }
            catch (Exception ex) { return ApiResponse<ShiftDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<ShiftDTO>> CreateShiftAsync(CreateShiftDTO dto, int createdBy)
        {
            try
            {
                var exists = await _uow.Shifts.AnyAsync(s => s.Code == dto.Code);
                if (exists) return ApiResponse<ShiftDTO>.ErrorResponse("Shift code already exists");

                var entity = _mapper.Map<Shift>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.Shifts.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<ShiftDTO>.SuccessResponse(_mapper.Map<ShiftDTO>(entity), "Shift created");
            }
            catch (Exception ex) { return ApiResponse<ShiftDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<ShiftDTO>> UpdateShiftAsync(int id, CreateShiftDTO dto, int updatedBy)
        {
            try
            {
                var entity = await _uow.Shifts.GetByIdAsync(id);
                if (entity == null) return ApiResponse<ShiftDTO>.ErrorResponse("Not found");

                _mapper.Map(dto, entity);
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedBy = updatedBy;

                await _uow.Shifts.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<ShiftDTO>.SuccessResponse(_mapper.Map<ShiftDTO>(entity), "Updated");
            }
            catch (Exception ex) { return ApiResponse<ShiftDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<ShiftAssignmentDTO>> AssignShiftAsync(CreateShiftAssignmentDTO dto, int createdBy)
        {
            try
            {
                var current = await _uow.ShiftAssignments.FindAsync(
                    sa => sa.EmployeeId == dto.EmployeeId && sa.IsActive);
                foreach (var sa in current)
                {
                    sa.IsActive = false;
                    sa.EffectiveTo = dto.EffectiveFrom.AddDays(-1);
                    await _uow.ShiftAssignments.UpdateAsync(sa);
                }

                var entity = _mapper.Map<ShiftAssignment>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.ShiftAssignments.AddAsync(entity);
                await _uow.SaveChangesAsync();

                var result = await _uow.ShiftAssignments.GetByIdAsync(entity.Id, sa => sa.Employee, sa => sa.Shift);
                return ApiResponse<ShiftAssignmentDTO>.SuccessResponse(_mapper.Map<ShiftAssignmentDTO>(result), "Shift assigned");
            }
            catch (Exception ex) { return ApiResponse<ShiftAssignmentDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<ShiftAssignmentDTO>> GetCurrentShiftByEmployeeAsync(int employeeId)
        {
            try
            {
                var assignment = await _uow.ShiftAssignments.FirstOrDefaultAsync(
                    sa => sa.EmployeeId == employeeId && sa.IsActive,
                    sa => sa.Employee, sa => sa.Shift);
                if (assignment == null) return ApiResponse<ShiftAssignmentDTO>.ErrorResponse("No shift assigned");
                return ApiResponse<ShiftAssignmentDTO>.SuccessResponse(_mapper.Map<ShiftAssignmentDTO>(assignment));
            }
            catch (Exception ex) { return ApiResponse<ShiftAssignmentDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<IEnumerable<AttendanceDTO>>> GetAttendanceByEmployeeAsync(int employeeId, int month, int year)
        {
            try
            {
                var attendances = await _uow.Attendances.FindAsync(
                    a => a.EmployeeId == employeeId && a.Date.Month == month && a.Date.Year == year,
                    a => a.Employee, a => a.Shift);
                return ApiResponse<IEnumerable<AttendanceDTO>>.SuccessResponse(_mapper.Map<IEnumerable<AttendanceDTO>>(attendances));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<AttendanceDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<AttendanceSummaryDTO>> GetAttendanceSummaryAsync(int employeeId, int month, int year)
        {
            try
            {
                var attendances = (await _uow.Attendances.FindAsync(
                    a => a.EmployeeId == employeeId && a.Date.Month == month && a.Date.Year == year,
                    a => a.Employee)).ToList();

                var employee = await _uow.Employees.GetByIdAsync(employeeId);

                return ApiResponse<AttendanceSummaryDTO>.SuccessResponse(new AttendanceSummaryDTO
                {
                    EmployeeId = employeeId,
                    EmployeeName = employee?.FullName,
                    EmployeeCode = employee?.EmployeeCode,
                    Month = month,
                    Year = year,
                    TotalWorkingDays = attendances.Count(a => a.Status != "Holiday" && a.Status != "Weekend"),
                    PresentDays = attendances.Count(a => a.Status == "Present"),
                    AbsentDays = attendances.Count(a => a.Status == "Absent"),
                    LateDays = attendances.Count(a => a.Status == "Late"),
                    HalfDays = attendances.Count(a => a.Status == "Half Day"),
                    LeaveDays = attendances.Count(a => a.Status == "On Leave"),
                    HolidayDays = attendances.Count(a => a.Status == "Holiday"),
                    TotalWorkingHours = attendances.Sum(a => a.WorkingHours),
                    TotalOvertimeHours = attendances.Sum(a => a.OvertimeHours)
                });
            }
            catch (Exception ex) { return ApiResponse<AttendanceSummaryDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<IEnumerable<AttendanceSummaryDTO>>> GetMonthlyAttendanceSummaryAsync(int month, int year, int? departmentId = null)
        {
            try
            {
                var employees = (await _uow.Employees.FindAsync(
                    e => e.IsActive && (!departmentId.HasValue || e.DepartmentId == departmentId.Value))).ToList();

                var summaries = new List<AttendanceSummaryDTO>();
                foreach (var emp in employees)
                {
                    var result = await GetAttendanceSummaryAsync(emp.Id, month, year);
                    if (result.Success) summaries.Add(result.Data);
                }

                return ApiResponse<IEnumerable<AttendanceSummaryDTO>>.SuccessResponse(summaries);
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<AttendanceSummaryDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<AttendanceDTO>> CreateManualAttendanceAsync(CreateManualAttendanceDTO dto, int createdBy)
        {
            try
            {
                var entity = _mapper.Map<ManualAttendance>(dto);
                entity.EnteredBy = createdBy;
                entity.EnteredDate = DateTime.Now;
                entity.Status = "Pending";
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.ManualAttendances.AddAsync(entity);
                await _uow.SaveChangesAsync();

                return ApiResponse<AttendanceDTO>.SuccessResponse(new AttendanceDTO
                {
                    EmployeeId = entity.EmployeeId,
                    Date = entity.Date,
                    CheckInTime = entity.CheckInTime,
                    CheckOutTime = entity.CheckOutTime,
                    IsManualEntry = true,
                    Remarks = entity.Reason
                }, "Manual attendance submitted for approval");
            }
            catch (Exception ex) { return ApiResponse<AttendanceDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<bool>> ApproveManualAttendanceAsync(int id, ApproveManualAttendanceDTO dto, int approverId)
        {
            try
            {
                var manual = await _uow.ManualAttendances.GetByIdAsync(id);
                if (manual == null) return ApiResponse<bool>.ErrorResponse("Not found");

                manual.Status = dto.Status;
                manual.ApprovedBy = approverId;
                manual.ApprovalDate = DateTime.Now;
                manual.UpdatedAt = DateTime.Now;
                manual.UpdatedBy = approverId;

                if (dto.Status == "Approved")
                {
                    var existing = await _uow.Attendances.FirstOrDefaultAsync(
                        a => a.EmployeeId == manual.EmployeeId && a.Date.Date == manual.Date.Date);

                    if (existing != null)
                    {
                        existing.CheckInTime = manual.CheckInTime;
                        existing.CheckOutTime = manual.CheckOutTime;
                        existing.IsManualEntry = true;
                        existing.UpdatedAt = DateTime.Now;
                        await _uow.Attendances.UpdateAsync(existing);
                    }
                    else
                    {
                        var attendance = new Attendance
                        {
                            EmployeeId = manual.EmployeeId,
                            Date = manual.Date,
                            CheckInTime = manual.CheckInTime,
                            CheckOutTime = manual.CheckOutTime,
                            Status = "Present",
                            IsManualEntry = true,
                            CreatedAt = DateTime.Now,
                            CreatedBy = approverId,
                            IsActive = true
                        };
                        if (manual.CheckInTime.HasValue && manual.CheckOutTime.HasValue)
                            attendance.WorkingHours = (decimal)(manual.CheckOutTime.Value - manual.CheckInTime.Value).TotalHours;

                        await _uow.Attendances.AddAsync(attendance);
                    }
                }

                await _uow.ManualAttendances.UpdateAsync(manual);
                await _uow.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, $"Manual attendance {dto.Status.ToLower()}");
            }
            catch (Exception ex) { return ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<IEnumerable<HolidayDTO>>> GetHolidaysAsync(int year, int? locationId = null)
        {
            try
            {
                var holidays = await _uow.Holidays.FindAsync(
                    h => h.Date.Year == year && h.IsActive &&
                         (!locationId.HasValue || h.LocationId == locationId || h.LocationId == null),
                    h => h.Location);
                return ApiResponse<IEnumerable<HolidayDTO>>.SuccessResponse(_mapper.Map<IEnumerable<HolidayDTO>>(holidays));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<HolidayDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<HolidayDTO>> CreateHolidayAsync(CreateHolidayDTO dto, int createdBy)
        {
            try
            {
                var entity = _mapper.Map<Holiday>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.Holidays.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<HolidayDTO>.SuccessResponse(_mapper.Map<HolidayDTO>(entity), "Holiday created");
            }
            catch (Exception ex) { return ApiResponse<HolidayDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<bool>> DeleteHolidayAsync(int id)
        {
            try
            {
                var entity = await _uow.Holidays.GetByIdAsync(id);
                if (entity == null) return ApiResponse<bool>.ErrorResponse("Not found");
                entity.IsActive = false;
                await _uow.Holidays.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Holiday deleted");
            }
            catch (Exception ex) { return ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }
    }
}