using HRMS.Models.Common;

namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeCashPayment : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public bool PreferCashPayment { get; set; }
        public string Reason { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
