namespace HRMS.Models.Payroll
{
    public class BonusProcess
    {
        public int Id { get; set; }
        public string BonusCode { get; set; }
        public int BonusTypeId { get; set; }
        public string BonusYear { get; set; }
        public string BonusMonth { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } // Processed, Approved, Paid
        public decimal TotalAmount { get; set; }
        public int TotalEmployees { get; set; }
        public DateTime ProcessedDate { get; set; }
        public int ProcessedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }

        // Navigation
        public BonusType BonusType { get; set; }
        public ICollection<EmployeeBonus> EmployeeBonuses { get; set; }
    }
}
