using HRMS.Models.Common;

namespace HRMS.Models.EmployeeDetails
{
    public class Bank : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string SwiftCode { get; set; }
        public bool IsActive { get; set; }

        // Navigation
        public ICollection<BankBranch> Branches { get; set; }
        public ICollection<EmployeeBankAccount> EmployeeAccounts { get; set; }
    }
}
