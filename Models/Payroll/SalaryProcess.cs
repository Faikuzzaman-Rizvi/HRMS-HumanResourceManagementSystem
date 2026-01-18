using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Payroll
{
    public class SalaryProcess
    {
        public int Id { get; set; }
        public string SalaryCode { get; set; }
        public int EmployeeId { get; set; }
        public int SalaryMonthId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        // Salary Components
        public decimal BasicSalary { get; set; }
        public decimal TotalBenefits { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetSalary { get; set; }

        // Attendance based
        public int WorkingDays { get; set; }
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int LeaveDays { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal OvertimeAmount { get; set; }

        // Loan
        public decimal LoanDeduction { get; set; }

        // Tax
        public decimal TaxDeduction { get; set; }

        // Payment
        public string PaymentMode { get; set; } // Bank, Cash
        public int? BankAccountId { get; set; }
        public string Status { get; set; } // Processed, Approved, Paid, Hold
        public DateTime ProcessedDate { get; set; }
        public int ProcessedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? PaidDate { get; set; }
        public string Remarks { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public SalaryMonth SalaryMonth { get; set; }
        public EmployeeBankAccount BankAccount { get; set; }
        public ICollection<SalaryBenefitDetail> BenefitDetails { get; set; }
        public ICollection<SalaryDeductionDetail> DeductionDetails { get; set; }
    }
}
