using AutoMapper;
using HRMS.DTOs.Common;
using HRMS.DTOs.Payroll;
using HRMS.Models.Payroll;
using HRMS.Repositories.Interfaces;
using HRMS.Services.Interfaces;

namespace HRMS.Services.Implementations
{
    public class PayrollService : IPayrollService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PayrollService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // ─── Benefit Type ─────────────────────────────────────────────
        public async Task<ApiResponse<IEnumerable<BenefitTypeDTO>>> GetAllBenefitTypesAsync()
        {
            try
            {
                var types = await _uow.BenefitTypes.FindAsync(t => t.IsActive);
                return ApiResponse<IEnumerable<BenefitTypeDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<BenefitTypeDTO>>(types));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<BenefitTypeDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<BenefitTypeDTO>> CreateBenefitTypeAsync(CreateBenefitTypeDTO dto, int createdBy)
        {
            try
            {
                var exists = await _uow.BenefitTypes.AnyAsync(t => t.Code == dto.Code);
                if (exists) return ApiResponse<BenefitTypeDTO>.ErrorResponse("Code already exists");

                var entity = _mapper.Map<BenefitType>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.BenefitTypes.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<BenefitTypeDTO>.SuccessResponse(_mapper.Map<BenefitTypeDTO>(entity), "Created");
            }
            catch (Exception ex) { return ApiResponse<BenefitTypeDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        // ─── Deduction Type ───────────────────────────────────────────
        public async Task<ApiResponse<IEnumerable<DeductionTypeDTO>>> GetAllDeductionTypesAsync()
        {
            try
            {
                var types = await _uow.DeductionTypes.FindAsync(t => t.IsActive);
                return ApiResponse<IEnumerable<DeductionTypeDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<DeductionTypeDTO>>(types));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<DeductionTypeDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<DeductionTypeDTO>> CreateDeductionTypeAsync(CreateDeductionTypeDTO dto, int createdBy)
        {
            try
            {
                var entity = _mapper.Map<DeductionType>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.DeductionTypes.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<DeductionTypeDTO>.SuccessResponse(_mapper.Map<DeductionTypeDTO>(entity), "Created");
            }
            catch (Exception ex) { return ApiResponse<DeductionTypeDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        // ─── Employee Benefit ─────────────────────────────────────────
        public async Task<ApiResponse<IEnumerable<EmployeeBenefitDTO>>> GetEmployeeBenefitsAsync(int employeeId)
        {
            try
            {
                var benefits = await _uow.EmployeeBenefits.FindAsync(
                    b => b.EmployeeId == employeeId && b.IsActive,
                    b => b.Employee, b => b.BenefitType);
                return ApiResponse<IEnumerable<EmployeeBenefitDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<EmployeeBenefitDTO>>(benefits));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<EmployeeBenefitDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<EmployeeBenefitDTO>> AddEmployeeBenefitAsync(CreateEmployeeBenefitDTO dto, int createdBy)
        {
            try
            {
                var exists = await _uow.EmployeeBenefits.AnyAsync(
                    b => b.EmployeeId == dto.EmployeeId && b.BenefitTypeId == dto.BenefitTypeId && b.IsActive);
                if (exists) return ApiResponse<EmployeeBenefitDTO>.ErrorResponse("Benefit already assigned");

                var entity = _mapper.Map<EmployeeBenefit>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.EmployeeBenefits.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<EmployeeBenefitDTO>.SuccessResponse(_mapper.Map<EmployeeBenefitDTO>(entity), "Benefit added");
            }
            catch (Exception ex) { return ApiResponse<EmployeeBenefitDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<bool>> DeleteEmployeeBenefitAsync(int id)
        {
            try
            {
                var entity = await _uow.EmployeeBenefits.GetByIdAsync(id);
                if (entity == null) return ApiResponse<bool>.ErrorResponse("Not found");
                entity.IsActive = false;
                await _uow.EmployeeBenefits.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Deleted");
            }
            catch (Exception ex) { return ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        // ─── Employee Deduction ───────────────────────────────────────
        public async Task<ApiResponse<IEnumerable<EmployeeDeductionDTO>>> GetEmployeeDeductionsAsync(int employeeId)
        {
            try
            {
                var deductions = await _uow.EmployeeDeductions.FindAsync(
                    d => d.EmployeeId == employeeId && d.IsActive,
                    d => d.Employee, d => d.DeductionType);
                return ApiResponse<IEnumerable<EmployeeDeductionDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<EmployeeDeductionDTO>>(deductions));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<EmployeeDeductionDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<EmployeeDeductionDTO>> AddEmployeeDeductionAsync(CreateEmployeeDeductionDTO dto, int createdBy)
        {
            try
            {
                var entity = _mapper.Map<EmployeeDeduction>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.EmployeeDeductions.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<EmployeeDeductionDTO>.SuccessResponse(_mapper.Map<EmployeeDeductionDTO>(entity), "Deduction added");
            }
            catch (Exception ex) { return ApiResponse<EmployeeDeductionDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<bool>> DeleteEmployeeDeductionAsync(int id)
        {
            try
            {
                var entity = await _uow.EmployeeDeductions.GetByIdAsync(id);
                if (entity == null) return ApiResponse<bool>.ErrorResponse("Not found");
                entity.IsActive = false;
                await _uow.EmployeeDeductions.UpdateAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Deleted");
            }
            catch (Exception ex) { return ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        // ─── Loan ─────────────────────────────────────────────────────
        public async Task<ApiResponse<IEnumerable<LoanTypeDTO>>> GetAllLoanTypesAsync()
        {
            try
            {
                var types = await _uow.LoanTypes.FindAsync(t => t.IsActive);
                return ApiResponse<IEnumerable<LoanTypeDTO>>.SuccessResponse(_mapper.Map<IEnumerable<LoanTypeDTO>>(types));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<LoanTypeDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LoanTypeDTO>> CreateLoanTypeAsync(CreateLoanTypeDTO dto, int createdBy)
        {
            try
            {
                var entity = _mapper.Map<LoanType>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.LoanTypes.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<LoanTypeDTO>.SuccessResponse(_mapper.Map<LoanTypeDTO>(entity), "Created");
            }
            catch (Exception ex) { return ApiResponse<LoanTypeDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<IEnumerable<LoanDTO>>> GetLoansByEmployeeAsync(int employeeId)
        {
            try
            {
                var loans = await _uow.Loans.FindAsync(
                    l => l.EmployeeId == employeeId,
                    l => l.Employee, l => l.LoanType, l => l.Guarantor);
                return ApiResponse<IEnumerable<LoanDTO>>.SuccessResponse(_mapper.Map<IEnumerable<LoanDTO>>(loans));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<LoanDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LoanDTO>> CreateLoanAsync(CreateLoanDTO dto, int createdBy)
        {
            try
            {
                var loanType = await _uow.LoanTypes.GetByIdAsync(dto.LoanTypeId);
                if (loanType == null) return ApiResponse<LoanDTO>.ErrorResponse("Invalid loan type");

                if (dto.LoanAmount < loanType.MinAmount || dto.LoanAmount > loanType.MaxAmount)
                    return ApiResponse<LoanDTO>.ErrorResponse(
                        $"Loan amount must be between {loanType.MinAmount} and {loanType.MaxAmount}");

                var interestRate = loanType.InterestRate / 100 / 12;
                decimal monthlyInstallment = interestRate == 0
                    ? dto.LoanAmount / dto.TenureMonths
                    : dto.LoanAmount * interestRate *
                        (decimal)Math.Pow((double)(1 + interestRate), dto.TenureMonths) /
                        ((decimal)Math.Pow((double)(1 + interestRate), dto.TenureMonths) - 1);

                var entity = _mapper.Map<Loan>(dto);
                entity.LoanCode = $"LN{DateTime.Now:yyyyMMddHHmmss}";
                entity.InterestRate = loanType.InterestRate;
                entity.MonthlyInstallment = Math.Round(monthlyInstallment, 2);
                entity.TotalPayable = Math.Round(monthlyInstallment * dto.TenureMonths, 2);
                entity.RemainingAmount = dto.LoanAmount;
                entity.Status = "Pending";
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.Loans.AddAsync(entity);
                await _uow.SaveChangesAsync();

                // Generate installment schedule
                var installmentDate = dto.FirstInstallmentDate;
                var remainingPrincipal = dto.LoanAmount;

                for (int i = 1; i <= dto.TenureMonths; i++)
                {
                    var interestAmount = Math.Round(remainingPrincipal * loanType.InterestRate / 100 / 12, 2);
                    var principalAmount = Math.Round(monthlyInstallment - interestAmount, 2);
                    remainingPrincipal -= principalAmount;

                    await _uow.LoanInstallments.AddAsync(new LoanInstallment
                    {
                        LoanId = entity.Id,
                        InstallmentNumber = i,
                        DueDate = installmentDate,
                        InstallmentAmount = Math.Round(monthlyInstallment, 2),
                        PrincipalAmount = principalAmount,
                        InterestAmount = interestAmount,
                        Status = "Pending",
                        CreatedAt = DateTime.Now,
                        CreatedBy = createdBy,
                        IsActive = true
                    });
                    installmentDate = installmentDate.AddMonths(1);
                }

                await _uow.SaveChangesAsync();
                return ApiResponse<LoanDTO>.SuccessResponse(_mapper.Map<LoanDTO>(entity), "Loan application submitted");
            }
            catch (Exception ex) { return ApiResponse<LoanDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<LoanDTO>> ApproveLoanAsync(int id, int approverId)
        {
            try
            {
                var loan = await _uow.Loans.GetByIdAsync(id);
                if (loan == null) return ApiResponse<LoanDTO>.ErrorResponse("Loan not found");
                if (loan.Status != "Pending") return ApiResponse<LoanDTO>.ErrorResponse("Loan is not pending");

                loan.Status = "Active";
                loan.ApprovedBy = approverId;
                loan.ApprovalDate = DateTime.Now;
                loan.UpdatedAt = DateTime.Now;
                loan.UpdatedBy = approverId;

                await _uow.Loans.UpdateAsync(loan);
                await _uow.SaveChangesAsync();
                return ApiResponse<LoanDTO>.SuccessResponse(_mapper.Map<LoanDTO>(loan), "Loan approved");
            }
            catch (Exception ex) { return ApiResponse<LoanDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<IEnumerable<LoanInstallmentDTO>>> GetLoanInstallmentsAsync(int loanId)
        {
            try
            {
                var installments = await _uow.LoanInstallments.FindAsync(i => i.LoanId == loanId);
                return ApiResponse<IEnumerable<LoanInstallmentDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<LoanInstallmentDTO>>(installments));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<LoanInstallmentDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        // ─── Salary Month ─────────────────────────────────────────────
        public async Task<ApiResponse<IEnumerable<SalaryMonthDTO>>> GetAllSalaryMonthsAsync()
        {
            try
            {
                var months = await _uow.SalaryMonths.GetAllAsync();
                return ApiResponse<IEnumerable<SalaryMonthDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<SalaryMonthDTO>>(months));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<SalaryMonthDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<SalaryMonthDTO>> CreateSalaryMonthAsync(CreateSalaryMonthDTO dto, int createdBy)
        {
            try
            {
                var exists = await _uow.SalaryMonths.AnyAsync(s => s.Month == dto.Month && s.Year == dto.Year);
                if (exists) return ApiResponse<SalaryMonthDTO>.ErrorResponse("Salary month already exists");

                var entity = _mapper.Map<SalaryMonth>(dto);
                entity.Status = "Open";
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.SalaryMonths.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<SalaryMonthDTO>.SuccessResponse(_mapper.Map<SalaryMonthDTO>(entity), "Created");
            }
            catch (Exception ex) { return ApiResponse<SalaryMonthDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        // ─── Salary Processing ────────────────────────────────────────
        public async Task<ApiResponse<bool>> ProcessSalaryAsync(ProcessSalaryDTO dto, int processedBy)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var salaryMonth = await _uow.SalaryMonths.GetByIdAsync(dto.SalaryMonthId);
                if (salaryMonth == null) return ApiResponse<bool>.ErrorResponse("Salary month not found");
                if (salaryMonth.Status != "Open") return ApiResponse<bool>.ErrorResponse("Salary month is not open");

                var employees = dto.EmployeeIds?.Any() == true
                    ? (await _uow.Employees.FindAsync(e => dto.EmployeeIds.Contains(e.Id) && e.IsActive, e => e.Grade)).ToList()
                    : (await _uow.Employees.FindAsync(e => e.IsActive, e => e.Grade)).ToList();

                foreach (var emp in employees)
                {
                    var alreadyProcessed = await _uow.SalaryProcesses.AnyAsync(
                        sp => sp.EmployeeId == emp.Id && sp.SalaryMonthId == dto.SalaryMonthId);
                    if (alreadyProcessed) continue;

                    // Latest salary
                    var latestSalaryUpdate = (await _uow.SalaryUpdates.FindAsync(
                        su => su.EmployeeId == emp.Id && su.EffectiveFrom <= DateTime.Now))
                        .OrderByDescending(su => su.EffectiveFrom).FirstOrDefault();

                    var basicSalary = latestSalaryUpdate?.NewSalary ?? emp.Grade?.MinSalary ?? 0;

                    // Benefits
                    var benefits = (await _uow.EmployeeBenefits.FindAsync(
                        b => b.EmployeeId == emp.Id && b.IsActive, b => b.BenefitType)).ToList();

                    decimal totalBenefits = 0;
                    var benefitDetails = new List<SalaryBenefitDetail>();
                    foreach (var b in benefits)
                    {
                        decimal amount = b.CalculationType == "Fixed"
                            ? b.FixedAmount ?? 0
                            : basicSalary * (b.Percentage ?? 0) / 100;
                        totalBenefits += amount;
                        benefitDetails.Add(new SalaryBenefitDetail
                        {
                            BenefitTypeId = b.BenefitTypeId,
                            Amount = amount,
                            CreatedAt = DateTime.Now,
                            IsActive = true
                        });
                    }

                    // Deductions
                    var deductions = (await _uow.EmployeeDeductions.FindAsync(
                        d => d.EmployeeId == emp.Id && d.IsActive, d => d.DeductionType)).ToList();

                    decimal totalDeductions = 0;
                    var deductionDetails = new List<SalaryDeductionDetail>();
                    foreach (var d in deductions)
                    {
                        decimal amount = d.CalculationType == "Fixed"
                            ? d.FixedAmount ?? 0
                            : basicSalary * (d.Percentage ?? 0) / 100;
                        totalDeductions += amount;
                        deductionDetails.Add(new SalaryDeductionDetail
                        {
                            DeductionTypeId = d.DeductionTypeId,
                            Amount = amount,
                            CreatedAt = DateTime.Now,
                            IsActive = true
                        });
                    }

                    // Loan deduction
                    var pendingInstallments = (await _uow.LoanInstallments.FindAsync(
                        li => li.Status == "Pending" &&
                              li.DueDate.Month == salaryMonth.Month &&
                              li.DueDate.Year == salaryMonth.Year,
                        li => li.Loan))
                        .Where(li => li.Loan.EmployeeId == emp.Id && li.Loan.Status == "Active").ToList();

                    var loanDeduction = pendingInstallments.Sum(li => li.InstallmentAmount);

                    // Attendance
                    var attendances = (await _uow.Attendances.FindAsync(
                        a => a.EmployeeId == emp.Id &&
                             a.Date.Month == salaryMonth.Month &&
                             a.Date.Year == salaryMonth.Year)).ToList();

                    var workingDays = attendances.Count(a => a.Status != "Holiday" && a.Status != "Weekend");
                    var presentDays = attendances.Count(a => a.Status == "Present" || a.Status == "Late");
                    var absentDays = attendances.Count(a => a.Status == "Absent");
                    var leaveDays = attendances.Count(a => a.Status == "On Leave");
                    var overtimeHours = attendances.Sum(a => a.OvertimeHours);
                    var overtimeAmount = overtimeHours * (basicSalary / 30 / 8);

                    var perDaySalary = workingDays > 0 ? (basicSalary + totalBenefits) / workingDays : 0;
                    totalDeductions += absentDays * perDaySalary + loanDeduction;

                    var grossSalary = basicSalary + totalBenefits + overtimeAmount;
                    var netSalary = grossSalary - totalDeductions;

                    var bankAccount = await _uow.EmployeeBankAccounts.FirstOrDefaultAsync(
                        ba => ba.EmployeeId == emp.Id && ba.IsPrimary && ba.IsActive);

                    var salaryProcess = new SalaryProcess
                    {
                        SalaryCode = $"SAL{salaryMonth.Year}{salaryMonth.Month:D2}{emp.Id:D4}",
                        EmployeeId = emp.Id,
                        SalaryMonthId = dto.SalaryMonthId,
                        Month = salaryMonth.Month,
                        Year = salaryMonth.Year,
                        BasicSalary = basicSalary,
                        TotalBenefits = totalBenefits,
                        GrossSalary = grossSalary,
                        TotalDeductions = totalDeductions,
                        NetSalary = netSalary,
                        WorkingDays = workingDays,
                        PresentDays = presentDays,
                        AbsentDays = absentDays,
                        LeaveDays = leaveDays,
                        OvertimeHours = overtimeHours,
                        OvertimeAmount = overtimeAmount,
                        LoanDeduction = loanDeduction,
                        PaymentMode = bankAccount != null ? "Bank" : "Cash",
                        BankAccountId = bankAccount?.Id,
                        Status = "Processed",
                        ProcessedDate = DateTime.Now,
                        ProcessedBy = processedBy,
                        CreatedAt = DateTime.Now,
                        CreatedBy = processedBy,
                        IsActive = true,
                        BenefitDetails = benefitDetails,
                        DeductionDetails = deductionDetails
                    };

                    await _uow.SalaryProcesses.AddAsync(salaryProcess);

                    // Update loan installments
                    foreach (var inst in pendingInstallments)
                    {
                        inst.Status = "Paid";
                        inst.PaidDate = DateTime.Now;
                        await _uow.LoanInstallments.UpdateAsync(inst);

                        var loan = await _uow.Loans.GetByIdAsync(inst.LoanId);
                        loan.PaidAmount += inst.InstallmentAmount;
                        loan.RemainingAmount -= inst.PrincipalAmount;
                        if (loan.RemainingAmount <= 0) { loan.Status = "Settled"; loan.SettlementDate = DateTime.Now; }
                        await _uow.Loans.UpdateAsync(loan);
                    }
                }

                salaryMonth.Status = "Processed";
                salaryMonth.ProcessedDate = DateTime.Now;
                salaryMonth.ProcessedBy = processedBy;
                await _uow.SalaryMonths.UpdateAsync(salaryMonth);

                await _uow.CommitTransactionAsync();
                return ApiResponse<bool>.SuccessResponse(true, $"Salary processed for {employees.Count} employees");
            }
            catch (Exception ex)
            {
                await _uow.RollbackTransactionAsync();
                return ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<SalaryProcessDTO>>> GetSalarySheetAsync(int salaryMonthId)
        {
            try
            {
                var processes = await _uow.SalaryProcesses.FindAsync(
                    sp => sp.SalaryMonthId == salaryMonthId,
                    sp => sp.Employee, sp => sp.BenefitDetails, sp => sp.DeductionDetails);
                return ApiResponse<IEnumerable<SalaryProcessDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<SalaryProcessDTO>>(processes));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<SalaryProcessDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<SalaryProcessDTO>> GetEmployeeSalarySlipAsync(int salaryMonthId, int employeeId)
        {
            try
            {
                var process = await _uow.SalaryProcesses.FirstOrDefaultAsync(
                    sp => sp.SalaryMonthId == salaryMonthId && sp.EmployeeId == employeeId,
                    sp => sp.Employee, sp => sp.SalaryMonth,
                    sp => sp.BenefitDetails, sp => sp.DeductionDetails);

                if (process == null) return ApiResponse<SalaryProcessDTO>.ErrorResponse("Salary slip not found");
                return ApiResponse<SalaryProcessDTO>.SuccessResponse(_mapper.Map<SalaryProcessDTO>(process));
            }
            catch (Exception ex) { return ApiResponse<SalaryProcessDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<bool>> ApproveSalaryAsync(int salaryMonthId, int approvedBy)
        {
            try
            {
                var month = await _uow.SalaryMonths.GetByIdAsync(salaryMonthId);
                if (month == null) return ApiResponse<bool>.ErrorResponse("Not found");
                if (month.Status != "Processed") return ApiResponse<bool>.ErrorResponse("Salary is not processed yet");

                month.Status = "Approved";
                month.ApprovedDate = DateTime.Now;
                month.ApprovedBy = approvedBy;

                var processes = await _uow.SalaryProcesses.FindAsync(sp => sp.SalaryMonthId == salaryMonthId);
                foreach (var sp in processes)
                {
                    sp.Status = "Approved";
                    sp.ApprovedDate = DateTime.Now;
                    sp.ApprovedBy = approvedBy;
                    await _uow.SalaryProcesses.UpdateAsync(sp);
                }

                await _uow.SalaryMonths.UpdateAsync(month);
                await _uow.SaveChangesAsync();
                return ApiResponse<bool>.SuccessResponse(true, "Salary approved");
            }
            catch (Exception ex) { return ApiResponse<bool>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        // ─── Salary Update ────────────────────────────────────────────
        public async Task<ApiResponse<SalaryUpdateDTO>> UpdateEmployeeSalaryAsync(CreateSalaryUpdateDTO dto, int createdBy)
        {
            try
            {
                var employee = await _uow.Employees.GetByIdAsync(dto.EmployeeId);
                if (employee == null) return ApiResponse<SalaryUpdateDTO>.ErrorResponse("Employee not found");

                var lastSalary = (await _uow.SalaryUpdates.FindAsync(su => su.EmployeeId == dto.EmployeeId))
                    .OrderByDescending(su => su.EffectiveFrom).FirstOrDefault();

                var previousSalary = lastSalary?.NewSalary ?? 0;
                var incrementAmount = dto.NewSalary - previousSalary;
                var incrementPct = previousSalary > 0 ? (incrementAmount / previousSalary) * 100 : 0;

                var entity = new SalaryUpdate
                {
                    EmployeeId = dto.EmployeeId,
                    PreviousSalary = previousSalary,
                    NewSalary = dto.NewSalary,
                    IncrementAmount = incrementAmount,
                    IncrementPercentage = Math.Round(incrementPct, 2),
                    EffectiveFrom = dto.EffectiveFrom,
                    Reason = dto.Reason,
                    CreatedAt = DateTime.Now,
                    CreatedBy = createdBy,
                    IsActive = true
                };

                await _uow.SalaryUpdates.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<SalaryUpdateDTO>.SuccessResponse(_mapper.Map<SalaryUpdateDTO>(entity), "Salary updated");
            }
            catch (Exception ex) { return ApiResponse<SalaryUpdateDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<IEnumerable<SalaryUpdateDTO>>> GetSalaryHistoryAsync(int employeeId)
        {
            try
            {
                var history = (await _uow.SalaryUpdates.FindAsync(su => su.EmployeeId == employeeId, su => su.Employee))
                    .OrderByDescending(su => su.EffectiveFrom);
                return ApiResponse<IEnumerable<SalaryUpdateDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<SalaryUpdateDTO>>(history));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<SalaryUpdateDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        // ─── Bonus ────────────────────────────────────────────────────
        public async Task<ApiResponse<IEnumerable<BonusTypeDTO>>> GetAllBonusTypesAsync()
        {
            try
            {
                var types = await _uow.BonusTypes.FindAsync(t => t.IsActive);
                return ApiResponse<IEnumerable<BonusTypeDTO>>.SuccessResponse(_mapper.Map<IEnumerable<BonusTypeDTO>>(types));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<BonusTypeDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<BonusTypeDTO>> CreateBonusTypeAsync(CreateBonusTypeDTO dto, int createdBy)
        {
            try
            {
                var entity = _mapper.Map<BonusType>(dto);
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = createdBy;
                entity.IsActive = true;

                await _uow.BonusTypes.AddAsync(entity);
                await _uow.SaveChangesAsync();
                return ApiResponse<BonusTypeDTO>.SuccessResponse(_mapper.Map<BonusTypeDTO>(entity), "Created");
            }
            catch (Exception ex) { return ApiResponse<BonusTypeDTO>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }

        public async Task<ApiResponse<BonusProcessDTO>> ProcessBonusAsync(CreateBonusProcessDTO dto, int processedBy)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var bonusType = await _uow.BonusTypes.GetByIdAsync(dto.BonusTypeId);
                if (bonusType == null) return ApiResponse<BonusProcessDTO>.ErrorResponse("Bonus type not found");

                var employees = dto.EmployeeIds?.Any() == true
                    ? (await _uow.Employees.FindAsync(e => dto.EmployeeIds.Contains(e.Id) && e.IsActive, e => e.Grade)).ToList()
                    : (await _uow.Employees.FindAsync(e => e.IsActive, e => e.Grade)).ToList();

                var bonusProcess = new BonusProcess
                {
                    BonusCode = $"BON{DateTime.Now:yyyyMMddHHmmss}",
                    BonusTypeId = dto.BonusTypeId,
                    BonusYear = dto.BonusYear,
                    BonusMonth = dto.BonusMonth,
                    PaymentDate = dto.PaymentDate,
                    Status = "Processed",
                    TotalEmployees = employees.Count,
                    ProcessedDate = DateTime.Now,
                    ProcessedBy = processedBy,
                    CreatedAt = DateTime.Now,
                    CreatedBy = processedBy,
                    IsActive = true
                };

                await _uow.BonusProcesses.AddAsync(bonusProcess);
                await _uow.SaveChangesAsync();

                decimal totalAmount = 0;
                foreach (var emp in employees)
                {
                    var latestSalary = (await _uow.SalaryUpdates.FindAsync(
                        su => su.EmployeeId == emp.Id && su.EffectiveFrom <= DateTime.Now))
                        .OrderByDescending(su => su.EffectiveFrom).FirstOrDefault();

                    var basicSalary = latestSalary?.NewSalary ?? emp.Grade?.MinSalary ?? 0;
                    var bonusAmount = basicSalary;
                    var taxDeduction = bonusType.IsTaxable ? bonusAmount * 0.10m : 0;
                    var netBonus = bonusAmount - taxDeduction;
                    totalAmount += netBonus;

                    var bankAccount = await _uow.EmployeeBankAccounts.FirstOrDefaultAsync(
                        ba => ba.EmployeeId == emp.Id && ba.IsPrimary && ba.IsActive);

                    await _uow.EmployeeBonuses.AddAsync(new EmployeeBonus
                    {
                        BonusProcessId = bonusProcess.Id,
                        EmployeeId = emp.Id,
                        BonusAmount = bonusAmount,
                        TaxDeduction = taxDeduction,
                        NetBonus = netBonus,
                        PaymentMode = bankAccount != null ? "Bank" : "Cash",
                        BankAccountId = bankAccount?.Id,
                        Status = "Processed",
                        CreatedAt = DateTime.Now,
                        CreatedBy = processedBy,
                        IsActive = true
                    });
                }

                bonusProcess.TotalAmount = totalAmount;
                await _uow.BonusProcesses.UpdateAsync(bonusProcess);

                await _uow.CommitTransactionAsync();
                return ApiResponse<BonusProcessDTO>.SuccessResponse(
                    _mapper.Map<BonusProcessDTO>(bonusProcess), "Bonus processed successfully");
            }
            catch (Exception ex)
            {
                await _uow.RollbackTransactionAsync();
                return ApiResponse<BonusProcessDTO>.ErrorResponse("Error", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<EmployeeBonusDTO>>> GetBonusDetailsAsync(int bonusProcessId)
        {
            try
            {
                var bonuses = await _uow.EmployeeBonuses.FindAsync(
                    b => b.BonusProcessId == bonusProcessId, b => b.Employee);
                return ApiResponse<IEnumerable<EmployeeBonusDTO>>.SuccessResponse(
                    _mapper.Map<IEnumerable<EmployeeBonusDTO>>(bonuses));
            }
            catch (Exception ex) { return ApiResponse<IEnumerable<EmployeeBonusDTO>>.ErrorResponse("Error", new List<string> { ex.Message }); }
        }
    }
}