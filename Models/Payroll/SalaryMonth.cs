namespace HRMS.Models.Payroll
{
    public class SalaryMonth
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } // Open, Processed, Approved, Paid, Closed
        public DateTime? ProcessedDate { get; set; }
        public int? ProcessedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }

        // Navigation
        public ICollection<SalaryProcess> SalaryProcesses { get; set; }
    }
}
