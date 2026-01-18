using HRMS.Models.EmployeeDetails;
using HRMS.Models.Organization;

namespace HRMS.Models.Payroll
{
    public class BenefitParameterization
    {
        public int Id { get; set; }
        public int BenefitTypeId { get; set; }
        public int? DesignationId { get; set; }
        public int? GradeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? LocationId { get; set; }
        public string CalculationType { get; set; } // Fixed, Percentage
        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

        // Navigation
        public BenefitType BenefitType { get; set; }
        public Designation Designation { get; set; }
        public Grade Grade { get; set; }
        public Department Department { get; set; }
        public Location Location { get; set; }
    }
}
