namespace HRMS.Models.Payroll
{
    public class LoanType
    {
        public int Id { get; set; }
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
        public bool IsActive { get; set; }

        // Navigation
        public ICollection<Loan> Loans { get; set; }
    }
}
