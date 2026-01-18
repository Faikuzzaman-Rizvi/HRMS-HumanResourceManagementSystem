using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Payroll
{
    public class EmployeeBonus
    {
        public int Id { get; set; }
        public int BonusProcessId { get; set; }
        public int EmployeeId { get; set; }
        public decimal BonusAmount { get; set; }
        public decimal TaxDeduction { get; set; }
        public decimal NetBonus { get; set; }
        public string PaymentMode { get; set; }
        public int? BankAccountId { get; set; }
        public string Status { get; set; }
        public DateTime? PaidDate { get; set; }

        // Navigation
        public BonusProcess BonusProcess { get; set; }
        public Employee Employee { get; set; }
        public EmployeeBankAccount BankAccount { get; set; }
    }
}
