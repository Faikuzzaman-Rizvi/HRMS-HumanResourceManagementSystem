using AutoMapper;
using HRMS.DTOs.Common;
using HRMS.DTOs.TimeAttendance;
using HRMS.Models.TimeAttendance;
using HRMS.Repositories.Interfaces;
using HRMS.Services.Interfaces;

namespace HRMS.Services.Implementations
{
    public class LeaveService : ILeaveService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LeaveService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<LeaveTypeDTO>>> GetAllLeaveTypesAsync()
        {
            try
            {
                var types = await _uow.LeaveTypes.FindAsync(t => t.IsActive);
                return ApiResponse<IEnumerable<LeaveTypeDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<LeaveTypeDTO>>(types));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<LeaveTypeDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LeaveTypeDTO>> GetLeaveTypeByIdAsync(int id)
        {
            try
            {
                var type = await _uow.LeaveTypes.GetByIdAsync(id);
                if (type == null || !type.IsActive)
                    return ApiResponse<LeaveTypeDTO>.ErrorResponse("Leave type not found");
                return ApiResponse<LeaveTypeDTO>.SuccessResponse(_mapper.Map<LeaveTypeDTO>(type));
            }
            catch (Exception ex) { return ApiResponse<LeaveTypeDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LeaveTypeDTO>> CreateLeaveTypeAsync(CreateLeaveTypeDTO dto, int createdBy)
        {
            try
            {
                var exists = await _uow.LeaveTypes.AnyAsync(t => t.Code == dto.Code);
                if (exists) return ApiResponse<LeaveTypeDTO>.ErrorResponse("Leave type code already exists");

                var entity = _mapper.Map<LeaveType>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.LeaveTypes.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<LeaveTypeDTO>.SuccessResponse(_mapper.Map<LeaveTypeDTO>(entity), "Leave type created");
            }
            catch (Exception ex) { return ApiResponse<LeaveTypeDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LeaveTypeDTO>> UpdateLeaveTypeAsync(int id, CreateLeaveTypeDTO dto, int updatedBy)
        {
            try
            {
                var entity = await _uow.LeaveTypes.GetByIdAsync(id);
                if (entity == null) return ApiResponse<LeaveTypeDTO>.ErrorResponse("Not found");

                _mapper.Map(dto, entity);
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedBy = updatedBy;

                await _uow.LeaveTypes.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<LeaveTypeDTO>.SuccessResponse(_mapper.Map<LeaveTypeDTO>(entity), "Updated");
            }
            catch (Exception ex) { return ApiResponse<LeaveTypeDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<bool>> DeleteLeaveTypeAsync(int id)
        {
            try
            {
                var entity = await _uow.LeaveTypes.GetByIdAsync(id);
                if (entity == null) return ApiResponse<bool>.ErrorResponse("Not found");
                entity.IsActive = false;
                entity.UpdatedAt = DateTime.Now;
                await _uow.LeaveTypes.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Deleted");
            }
            catch (Exception ex) { return ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<IEnumerable<LeaveYearDTO>>> GetAllLeaveYearsAsync()
        {
            try
            {
                var years = await _uow.LeaveYears.GetAllAsync();
                return ApiResponse<IEnumerable<LeaveYearDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<LeaveYearDTO>>(years));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<LeaveYearDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LeaveYearDTO>> CreateLeaveYearAsync(CreateLeaveYearDTO dto, int createdBy)
        {
            try
            {
                if (dto.IsCurrent)
                {
                    var existing = await _uow.LeaveYears.FindAsync(y => y.IsCurrent);
                    foreach (var y in existing) { y.IsCurrent = false; await _uow.LeaveYears.UpdateAsync(y); }
                }

                var entity = _mapper.Map<LeaveYear>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.LeaveYears.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<LeaveYearDTO>.SuccessResponse(_mapper.Map<LeaveYearDTO>(entity), "Leave year created");
            }
            catch (Exception ex) { return ApiResponse<LeaveYearDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<IEnumerable<LeaveBalanceDTO>>> GetLeaveBalanceByEmployeeAsync(int employeeId, int leaveYearId)
        {
            try
            {
                var balances = await _uow.LeaveBalances.FindAsync(
                    b => b.EmployeeId == employeeId && b.LeaveYearId == leaveYearId,
                    b => b.Employee, b => b.LeaveType, b => b.LeaveYear);
                return ApiResponse<IEnumerable<LeaveBalanceDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<LeaveBalanceDTO>>(balances));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<LeaveBalanceDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<bool>> AllocateLeaveBalanceAsync(int leaveYearId, int createdBy)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var leaveYear = await _uow.LeaveYears.GetByIdAsync(leaveYearId);
                if (leaveYear == null) return ApiResponse<bool>.ErrorResponse("Leave year not found");

                var employees = await _uow.Employees.FindAsync(e => e.IsActive);
                var leaveTypes = await _uow.LeaveTypes.FindAsync(t => t.IsActive);

                foreach (var emp in employees)
                {
                    foreach (var lt in leaveTypes)
                    {
                        var exists = await _uow.LeaveBalances.AnyAsync(
                            b => b.EmployeeId == emp.Id && b.LeaveTypeId == lt.Id && b.LeaveYearId == leaveYearId);

                        if (!exists)
                        {
                            await _uow.LeaveBalances.AddAsync(new LeaveBalance
                            {
                                EmployeeId = emp.Id,
                                LeaveTypeId = lt.Id,
                                LeaveYearId = leaveYearId,
                                AllocatedDays = lt.DefaultDaysPerYear,
                                OpeningBalance = lt.DefaultDaysPerYear,
                                RemainingDays = lt.DefaultDaysPerYear,
                                LastUpdated = DateTime.Now,
                                CreatedAt = DateTime.Now,
                                CreatedBy = createdBy,
                                IsActive = true
                            });
                        }
                    }
                }

                await _uow.CommitTransactionAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Leave balances allocated successfully");
            }
            catch (Exception ex)
            {
                await _uow.RollbackTransactionAsync();
                return ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<LeaveApplicationDTO>>> GetAllApplicationsAsync(int? employeeId = null, string status = null)
        {
            try
            {
                var apps = await _uow.LeaveApplications.FindAsync(
                    a => (!employeeId.HasValue || a.EmployeeId == employeeId.Value) &&
                         (string.IsNullOrEmpty(status) || a.Status == status),
                    a => a.Employee, a => a.LeaveType, a => a.Approver);
                return ApiResponse<IEnumerable<LeaveApplicationDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<LeaveApplicationDTO>>(apps));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<LeaveApplicationDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LeaveApplicationDTO>> GetApplicationByIdAsync(int id)
        {
            try
            {
                var app = await _uow.LeaveApplications.GetByIdAsync(
                    id, a => a.Employee, a => a.LeaveType, a => a.Approver);
                if (app == null) return ApiResponse<LeaveApplicationDTO>.ErrorResponse("Not found");
                return ApiResponse<LeaveApplicationDTO>.SuccessResponse(_mapper.Map<LeaveApplicationDTO>(app));
            }
            catch (Exception ex) { return ApiResponse<LeaveApplicationDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LeaveApplicationDTO>> ApplyLeaveAsync(CreateLeaveApplicationDTO dto, int createdBy)
        {
            try
            {
                var currentYear = await _uow.LeaveYears.FirstOrDefaultAsync(y => y.IsCurrent);
                if (currentYear == null)
                    return ApiResponse<LeaveApplicationDTO>.ErrorResponse("No active leave year found");

                var balance = await _uow.LeaveBalances.FirstOrDefaultAsync(
                    b => b.EmployeeId == dto.EmployeeId &&
                         b.LeaveTypeId == dto.LeaveTypeId &&
                         b.LeaveYearId == currentYear.Id);

                var totalDays = (decimal)(dto.ToDate - dto.FromDate).TotalDays + 1;

                if (balance == null || balance.RemainingDays < totalDays)
                    return ApiResponse<LeaveApplicationDTO>.ErrorResponse("Insufficient leave balance");

                var overlap = await _uow.LeaveApplications.AnyAsync(
                    a => a.EmployeeId == dto.EmployeeId &&
                         a.Status != "Cancelled" && a.Status != "Rejected" &&
                         a.FromDate <= dto.ToDate && a.ToDate >= dto.FromDate);
                if (overlap)
                    return ApiResponse<LeaveApplicationDTO>.ErrorResponse("Leave already applied for these dates");

                var leaveType = await _uow.LeaveTypes.GetByIdAsync(dto.LeaveTypeId);

                var entity = _mapper.Map<LeaveApplication>(dto);
                entity.LeaveCode = $"LV{DateTime.Now:yyyyMMddHHmmss}";
                entity.TotalDays = totalDays;
                entity.ApplicationDate = DateTime.Now;
                entity.Status = leaveType.RequiresApproval ? "Pending" : "Approved";
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.LeaveApplications.AddAsync(entity);

                if (!leaveType.RequiresApproval)
                {
                    balance.UsedDays += totalDays;
                    balance.RemainingDays -= totalDays;
                    balance.LastUpdated = DateTime.Now;
                    await _uow.LeaveBalances.UpdateAsync(balance);
                }

                await _uow.SaveChangesAsync();
                return ApiResponse<LeaveApplicationDTO>.SuccessResponse(
                    _mapper.Map<LeaveApplicationDTO>(entity), "Leave applied successfully");
            }
            catch (Exception ex) { return ApiResponse<LeaveApplicationDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LeaveApplicationDTO>> ApproveLeaveAsync(int id, ApproveLeaveDTO dto, int approverId)
        {
            try
            {
                var app = await _uow.LeaveApplications.GetByIdAsync(id, a => a.LeaveType);
                if (app == null) return ApiResponse<LeaveApplicationDTO>.ErrorResponse("Application not found");
                if (app.Status != "Pending") return ApiResponse<LeaveApplicationDTO>.ErrorResponse("Application is not pending");

                app.Status = dto.Status;
                app.ApprovedBy = approverId;
                app.ApprovalDate = DateTime.Now;
                app.ApproverComments = dto.Comments;
                app.UpdatedAt = DateTime.Now;
                app.UpdatedBy = approverId;

                if (dto.Status == "Approved")
                {
                    var currentYear = await _uow.LeaveYears.FirstOrDefaultAsync(y => y.IsCurrent);
                    var balance = await _uow.LeaveBalances.FirstOrDefaultAsync(
                        b => b.EmployeeId == app.EmployeeId &&
                             b.LeaveTypeId == app.LeaveTypeId &&
                             b.LeaveYearId == currentYear.Id);

                    if (balance != null)
                    {
                        balance.UsedDays += app.TotalDays;
                        balance.RemainingDays -= app.TotalDays;
                        balance.LastUpdated = DateTime.Now;
                        await _uow.LeaveBalances.UpdateAsync(balance);
                    }
                }

                await _uow.LeaveApplications.UpdateAsync(app);
                await _uow.SaveChangesAsync();
                return ApiResponse<LeaveApplicationDTO>.SuccessResponse(
                    _mapper.Map<LeaveApplicationDTO>(app), $"Leave {dto.Status.ToLower()}");
            }
            catch (Exception ex) { return ApiResponse<LeaveApplicationDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<bool>> CancelLeaveAsync(int id, int cancelledBy)
        {
            try
            {
                var app = await _uow.LeaveApplications.GetByIdAsync(id);
                if (app == null) return ApiResponse<bool>.ErrorResponse("Not found");
                if (app.Status == "Cancelled") return ApiResponse<bool>.ErrorResponse("Already cancelled");

                if (app.Status == "Approved")
                {
                    var currentYear = await _uow.LeaveYears.FirstOrDefaultAsync(y => y.IsCurrent);
                    var balance = await _uow.LeaveBalances.FirstOrDefaultAsync(
                        b => b.EmployeeId == app.EmployeeId &&
                             b.LeaveTypeId == app.LeaveTypeId &&
                             b.LeaveYearId == currentYear.Id);
                    if (balance != null)
                    {
                        balance.UsedDays -= app.TotalDays;
                        balance.RemainingDays += app.TotalDays;
                        balance.LastUpdated = DateTime.Now;
                        await _uow.LeaveBalances.UpdateAsync(balance);
                    }
                }

                app.Status = "Cancelled";
                app.UpdatedAt = DateTime.Now;
                app.UpdatedBy = cancelledBy;

                await _uow.LeaveApplications.UpdateAsync(app);
                await _uow.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Leave cancelled");
            }
            catch (Exception ex) { return ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }
    }
}