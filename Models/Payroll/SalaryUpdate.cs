using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Payroll
{
    public class SalaryUpdate
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal PreviousSalary { get; set; }
        public decimal NewSalary { get; set; }
        public decimal IncrementAmount { get; set; }
        public decimal IncrementPercentage { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public string Reason { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
