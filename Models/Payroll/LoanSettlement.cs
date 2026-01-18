namespace HRMS.Models.Payroll
{
    public class LoanSettlement
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public DateTime SettlementDate { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal SettlementAmount { get; set; }
        public decimal Waiver { get; set; }
        public string SettlementType { get; set; } // Full, Partial, Early
        public string Remarks { get; set; }
        public int SettledBy { get; set; }

        // Navigation
        public Loan Loan { get; set; }
    }
}
