using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Payroll
{
    public class DeductionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CalculationType { get; set; } // Fixed, Percentage, Formula
        public string CalculationBase { get; set; } // Basic, Gross, Custom
        public bool IsStatutory { get; set; } // Like Income Tax
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }

        // Navigation
        public ICollection<DeductionParameterization> Parameterizations { get; set; }
        public ICollection<EmployeeDeduction> EmployeeDeductions { get; set; }
    }
}
