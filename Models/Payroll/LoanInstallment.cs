namespace HRMS.Models.Payroll
{
    public class LoanInstallment
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int InstallmentNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public string Status { get; set; } // Pending, Paid, Overdue
        public DateTime? PaidDate { get; set; }
        public int? SalaryProcessId { get; set; } // Linked to salary deduction

        // Navigation
        public Loan Loan { get; set; }
    }
}
