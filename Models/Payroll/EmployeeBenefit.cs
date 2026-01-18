using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Payroll
{
    public class EmployeeBenefit
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int BenefitTypeId { get; set; }
        public string CalculationType { get; set; } // Fixed, Percentage
        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public bool IsActive { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public BenefitType BenefitType { get; set; }
    }
}
