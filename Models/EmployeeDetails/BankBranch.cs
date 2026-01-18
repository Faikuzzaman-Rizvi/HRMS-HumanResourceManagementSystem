namespace HRMS.Models.EmployeeDetails
{
    public class BankBranch
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string RoutingNumber { get; set; }
        public bool IsActive { get; set; }

        // Navigation
        public Bank Bank { get; set; }
        public ICollection<EmployeeBankAccount> EmployeeAccounts { get; set; }
    }
}
