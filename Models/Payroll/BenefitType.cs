namespace HRMS.Models.Payroll
{
    public class BenefitType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CalculationType { get; set; } // Fixed, Percentage, Formula
        public string CalculationBase { get; set; } // Basic, Gross, Custom
        public bool IsTaxable { get; set; }
        public bool IsStatutory { get; set; } // Like Provident Fund
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }

        // Navigation
        public ICollection<BenefitParameterization> Parameterizations { get; set; }
        public ICollection<EmployeeBenefit> EmployeeBenefits { get; set; }
    }
}
