using HRMS.Models.Common;
using HRMS.Models.Organization;
using System.Diagnostics;

namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeLifeCycle : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EventType { get; set; } // Joining, Promotion, Transfer, Salary Increment, Resignation, Termination
        public DateTime EventDate { get; set; }
        public DateTime EffectiveDate { get; set; }

        // Previous Values
        public int? PreviousDepartmentId { get; set; }
        public int? PreviousDesignationId { get; set; }
        public int? PreviousGradeId { get; set; }
        public int? PreviousLocationId { get; set; }
        public decimal? PreviousSalary { get; set; }

        // New Values
        public int? NewDepartmentId { get; set; }
        public int? NewDesignationId { get; set; }
        public int? NewGradeId { get; set; }
        public int? NewLocationId { get; set; }
        public decimal? NewSalary { get; set; }

        public string Reason { get; set; }
        public string Remarks { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public Department PreviousDepartment { get; set; }
        public Department NewDepartment { get; set; }
        public Designation PreviousDesignation { get; set; }
        public Designation NewDesignation { get; set; }
        public Grade PreviousGrade { get; set; }
        public Grade NewGrade { get; set; }
        public Location PreviousLocation { get; set; }
        public Location NewLocation { get; set; }
    }
}
