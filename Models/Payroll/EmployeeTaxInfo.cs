using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Payroll
{
    public class EmployeeTaxInfo
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int FiscalYear { get; set; }
        public string TIN { get; set; } // Tax Identification Number
        public decimal TaxableIncome { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal InvestmentRebate { get; set; }
        public decimal NetTaxPayable { get; set; }
        public decimal MonthlyDeduction { get; set; }

        // Navigation
        public Employee Employee { get; set; }
    }
}
