using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Payroll
{
    public class Loan
    {
        public int Id { get; set; }
        public string LoanCode { get; set; }
        public int EmployeeId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TenureMonths { get; set; }
        public decimal MonthlyInstallment { get; set; }
        public decimal TotalPayable { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime FirstInstallmentDate { get; set; }
        public int? GuarantorEmployeeId { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; } // Pending, Approved, Active, Settled, Cancelled
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime? SettlementDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public LoanType LoanType { get; set; }
        public Employee Guarantor { get; set; }
        public ICollection<LoanInstallment> Installments { get; set; }
    }
}
