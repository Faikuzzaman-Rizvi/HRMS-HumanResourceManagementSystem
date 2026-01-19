using HRMS.Models.Common;

namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeBankAccount : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int BankId { get; set; }
        public int BranchId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountTitle { get; set; }
        public string AccountType { get; set; } // Savings, Current
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public Bank Bank { get; set; }
        public BankBranch Branch { get; set; }
    }
}
