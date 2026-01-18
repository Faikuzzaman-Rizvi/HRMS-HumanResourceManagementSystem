namespace HRMS.Models.Payroll
{
    public class TaxSlab
    {
        public int Id { get; set; }
        public int FiscalYear { get; set; }
        public decimal MinIncome { get; set; }
        public decimal MaxIncome { get; set; }
        public decimal TaxRate { get; set; }
        public decimal FixedAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
