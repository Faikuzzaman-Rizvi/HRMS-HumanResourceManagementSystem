using HRMS.DTOs.Common;
using HRMS.DTOs.Payroll;

namespace HRMS.Services.Interfaces
{
    public interface IPayrollService
    {
        // Benefit & Deduction Types
        Task<ApiResponse<IEnumerable<BenefitTypeDTO>>> GetAllBenefitTypesAsync();
        Task<ApiResponse<BenefitTypeDTO>> CreateBenefitTypeAsync(CreateBenefitTypeDTO dto, int createdBy);
        Task<ApiResponse<IEnumerable<DeductionTypeDTO>>> GetAllDeductionTypesAsync();
        Task<ApiResponse<DeductionTypeDTO>> CreateDeductionTypeAsync(CreateDeductionTypeDTO dto, int createdBy);

        // Employee Benefit & Deduction
        Task<ApiResponse<IEnumerable<EmployeeBenefitDTO>>> GetEmployeeBenefitsAsync(int employeeId);
        Task<ApiResponse<EmployeeBenefitDTO>> AddEmployeeBenefitAsync(CreateEmployeeBenefitDTO dto, int createdBy);
        Task<ApiResponse<bool>> DeleteEmployeeBenefitAsync(int id);
        Task<ApiResponse<IEnumerable<EmployeeDeductionDTO>>> GetEmployeeDeductionsAsync(int employeeId);
        Task<ApiResponse<EmployeeDeductionDTO>> AddEmployeeDeductionAsync(CreateEmployeeDeductionDTO dto, int createdBy);
        Task<ApiResponse<bool>> DeleteEmployeeDeductionAsync(int id);

        // Loan
        Task<ApiResponse<IEnumerable<LoanTypeDTO>>> GetAllLoanTypesAsync();
        Task<ApiResponse<LoanTypeDTO>> CreateLoanTypeAsync(CreateLoanTypeDTO dto, int createdBy);
        Task<ApiResponse<IEnumerable<LoanDTO>>> GetLoansByEmployeeAsync(int employeeId);
        Task<ApiResponse<LoanDTO>> CreateLoanAsync(CreateLoanDTO dto, int createdBy);
        Task<ApiResponse<LoanDTO>> ApproveLoanAsync(int id, int approverId);
        Task<ApiResponse<IEnumerable<LoanInstallmentDTO>>> GetLoanInstallmentsAsync(int loanId);

        // Salary Month
        Task<ApiResponse<IEnumerable<SalaryMonthDTO>>> GetAllSalaryMonthsAsync();
        Task<ApiResponse<SalaryMonthDTO>> CreateSalaryMonthAsync(CreateSalaryMonthDTO dto, int createdBy);

        // Salary Processing
        Task<ApiResponse<IEnumerable<SalaryProcessDTO>>> GetSalarySheetAsync(int salaryMonthId);
        Task<ApiResponse<SalaryProcessDTO>> GetEmployeeSalarySlipAsync(int salaryMonthId, int employeeId);
        Task<ApiResponse<bool>> ProcessSalaryAsync(ProcessSalaryDTO dto, int processedBy);
        Task<ApiResponse<bool>> ApproveSalaryAsync(int salaryMonthId, int approvedBy);

        // Salary Update
        Task<ApiResponse<SalaryUpdateDTO>> UpdateEmployeeSalaryAsync(CreateSalaryUpdateDTO dto, int createdBy);
        Task<ApiResponse<IEnumerable<SalaryUpdateDTO>>> GetSalaryHistoryAsync(int employeeId);

        // Bonus
        Task<ApiResponse<IEnumerable<BonusTypeDTO>>> GetAllBonusTypesAsync();
        Task<ApiResponse<BonusTypeDTO>> CreateBonusTypeAsync(CreateBonusTypeDTO dto, int createdBy);
        Task<ApiResponse<BonusProcessDTO>> ProcessBonusAsync(CreateBonusProcessDTO dto, int processedBy);
        Task<ApiResponse<IEnumerable<EmployeeBonusDTO>>> GetBonusDetailsAsync(int bonusProcessId);
    }
}