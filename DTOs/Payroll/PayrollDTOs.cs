namespace HRMS.DTOs.Payroll
{
    // ─── Benefit Type ─────────────────────────
    public class BenefitTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CalculationType { get; set; }
        public string CalculationBase { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsStatutory { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateBenefitTypeDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CalculationType { get; set; }
        public string CalculationBase { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsStatutory { get; set; }
        public int DisplayOrder { get; set; }
    }

    // ─── Deduction Type ───────────────────────
    public class DeductionTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CalculationType { get; set; }
        public string CalculationBase { get; set; }
        public bool IsStatutory { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateDeductionTypeDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CalculationType { get; set; }
        public string CalculationBase { get; set; }
        public bool IsStatutory { get; set; }
        public int DisplayOrder { get; set; }
    }

    // ─── Employee Benefit ─────────────────────
    public class EmployeeBenefitDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int BenefitTypeId { get; set; }
        public string BenefitTypeName { get; set; }
        public string CalculationType { get; set; }
        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateEmployeeBenefitDTO
    {
        public int EmployeeId { get; set; }
        public int BenefitTypeId { get; set; }
        public string CalculationType { get; set; }
        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }

    // ─── Employee Deduction ───────────────────
    public class EmployeeDeductionDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DeductionTypeId { get; set; }
        public string DeductionTypeName { get; set; }
        public string CalculationType { get; set; }
        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateEmployeeDeductionDTO
    {
        public int EmployeeId { get; set; }
        public int DeductionTypeId { get; set; }
        public string CalculationType { get; set; }
        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }

    // ─── Loan ─────────────────────────────────
    public class LoanTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal MinAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int MaxTenureMonths { get; set; }
        public int MinTenureMonths { get; set; }
        public bool RequiresGuarantor { get; set; }
        public string EligibilityCriteria { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateLoanTypeDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal MinAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int MaxTenureMonths { get; set; }
        public int MinTenureMonths { get; set; }
        public bool RequiresGuarantor { get; set; }
        public string EligibilityCriteria { get; set; }
    }

    public class LoanDTO
    {
        public int Id { get; set; }
        public string LoanCode { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public int LoanTypeId { get; set; }
        public string LoanTypeName { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TenureMonths { get; set; }
        public decimal MonthlyInstallment { get; set; }
        public decimal TotalPayable { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime FirstInstallmentDate { get; set; }
        public string GuarantorName { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime? SettlementDate { get; set; }
    }

    public class CreateLoanDTO
    {
        public int EmployeeId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal LoanAmount { get; set; }
        public int TenureMonths { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime FirstInstallmentDate { get; set; }
        public int? GuarantorEmployeeId { get; set; }
        public string Purpose { get; set; }
    }

    public class LoanInstallmentDTO
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int InstallmentNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public string Status { get; set; }
        public DateTime? PaidDate { get; set; }
    }

    // ─── Salary ───────────────────────────────
    public class SalaryMonthDTO
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string MonthName { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }

    public class CreateSalaryMonthDTO
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime PaymentDate { get; set; }
    }

    public class SalaryProcessDTO
    {
        public int Id { get; set; }
        public string SalaryCode { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationTitle { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal TotalBenefits { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetSalary { get; set; }
        public int WorkingDays { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int LeaveDays { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal OvertimeAmount { get; set; }
        public decimal LoanDeduction { get; set; }
        public decimal TaxDeduction { get; set; }
        public string PaymentMode { get; set; }
        public string Status { get; set; }
        public DateTime ProcessedDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public List<SalaryBenefitDetailDTO> BenefitDetails { get; set; }
        public List<SalaryDeductionDetailDTO> DeductionDetails { get; set; }
    }

    public class SalaryBenefitDetailDTO
    {
        public int BenefitTypeId { get; set; }
        public string BenefitTypeName { get; set; }
        public decimal Amount { get; set; }
    }

    public class SalaryDeductionDetailDTO
    {
        public int DeductionTypeId { get; set; }
        public string DeductionTypeName { get; set; }
        public decimal Amount { get; set; }
    }

    public class ProcessSalaryDTO
    {
        public int SalaryMonthId { get; set; }
        public List<int> EmployeeIds { get; set; } // empty = process all
    }

    // ─── Bonus ────────────────────────────────
    public class BonusTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CalculationType { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreateBonusTypeDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CalculationType { get; set; }
        public bool IsTaxable { get; set; }
    }

    public class BonusProcessDTO
    {
        public int Id { get; set; }
        public string BonusCode { get; set; }
        public string BonusTypeName { get; set; }
        public string BonusYear { get; set; }
        public string BonusMonth { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalEmployees { get; set; }
        public DateTime ProcessedDate { get; set; }
    }

    public class CreateBonusProcessDTO
    {
        public int BonusTypeId { get; set; }
        public string BonusYear { get; set; }
        public string BonusMonth { get; set; }
        public DateTime PaymentDate { get; set; }
        public List<int> EmployeeIds { get; set; } // empty = all employees
    }

    public class EmployeeBonusDTO
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public decimal BonusAmount { get; set; }
        public decimal TaxDeduction { get; set; }
        public decimal NetBonus { get; set; }
        public string PaymentMode { get; set; }
        public string Status { get; set; }
        public DateTime? PaidDate { get; set; }
    }

    // ─── Salary Update / Increment ────────────
    public class SalaryUpdateDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal PreviousSalary { get; set; }
        public decimal NewSalary { get; set; }
        public decimal IncrementAmount { get; set; }
        public decimal IncrementPercentage { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public string Reason { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }

    public class CreateSalaryUpdateDTO
    {
        public int EmployeeId { get; set; }
        public decimal NewSalary { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public string Reason { get; set; }
    }
}