namespace HRMS.Models.Payroll
{
    public class SalaryBenefitDetail
    {
        public int Id { get; set; }
        public int SalaryProcessId { get; set; }
        public int BenefitTypeId { get; set; }
        public decimal Amount { get; set; }

        // Navigation
        public SalaryProcess SalaryProcess { get; set; }
        public BenefitType BenefitType { get; set; }
    }
}
