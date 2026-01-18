using HRMS.Models.EmployeeDetails;
using HRMS.Models.Organization;

namespace HRMS.Models.Payroll
{
    public class DeductionParameterization
    {
        public int Id { get; set; }
        public int DeductionTypeId { get; set; }
        public int? DesignationId { get; set; }
        public int? GradeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? LocationId { get; set; }
        public string CalculationType { get; set; }
        public decimal? FixedAmount { get; set; }
        public decimal? Percentage { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

        // Navigation
        public DeductionType DeductionType { get; set; }
        public Designation Designation { get; set; }
        public Grade Grade { get; set; }
        public Department Department { get; set; }
        public Location Location { get; set; }
    }
}
