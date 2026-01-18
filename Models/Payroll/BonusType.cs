namespace HRMS.Models.Payroll
{
    public class BonusType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CalculationType { get; set; } // Fixed, Percentage, Formula
        public bool IsTaxable { get; set; }
        public bool IsActive { get; set; }
    }
}
