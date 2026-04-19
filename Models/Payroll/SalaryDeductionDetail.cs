using HRMS.Models.Common;

namespace HRMS.Models.Payroll
{
    public class SalaryDeductionDetail : BaseEntity
    {
        public int Id { get; set; }
        public int SalaryProcessId { get; set; }
        public int DeductionTypeId { get; set; }
        public decimal Amount { get; set; }

        // Navigation
        public SalaryProcess SalaryProcess { get; set; }
        public DeductionType DeductionType { get; set; }
    }
}
