using HRMS.Models.EmployeeDetails;
using HRMS.Models.Organization;

namespace HRMS.Models.Recruitment
{
    public class JobRequisition
    {
        public int Id { get; set; }
        public string RequisitionCode { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public int? GradeId { get; set; }
        public int? LocationId { get; set; }
        public int VacancyCount { get; set; }
        public DateTime RequiredDate { get; set; }
        public string EmploymentType { get; set; } // Permanent, Contract, Temporary
        public string JobDescription { get; set; }
        public string RequiredSkills { get; set; }
        public string QualificationRequired { get; set; }
        public int MinExperience { get; set; }
        public int MaxExperience { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public string Priority { get; set; } // High, Medium, Low
        public string Status { get; set; } // Draft, Pending Approval, Approved, Rejected, In Progress, Closed
        public string Justification { get; set; }
        public int RequestedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Company Company { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }
        public Grade Grade { get; set; }
        public Location Location { get; set; }
        public Employee RequestedByEmployee { get; set; }
        public ICollection<RequisitionApproval> Approvals { get; set; }
        public ICollection<Interview> Interviews { get; set; }
    }
}
