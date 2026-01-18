using HRMS.Models.Organization;
using System.Diagnostics;

namespace HRMS.Models.EmployeeDetails
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; } // Computed
        public string Email { get; set; }
        public string PersonalEmail { get; set; }
        public string Phone { get; set; }
        public string EmergencyContact { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public string ProfilePictureUrl { get; set; }

        // Employment Details
        public DateTime JoiningDate { get; set; }
        public DateTime? ProbationEndDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public DateTime? LastWorkingDate { get; set; }
        public string EmploymentStatus { get; set; } // Probation, Confirmed, Notice Period, Resigned, Terminated
        public string EmploymentType { get; set; } // Permanent, Contract, Temporary, Intern

        // Organization Links
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public int GradeId { get; set; }
        public int? LocationId { get; set; }
        public int? WorkStationId { get; set; }
        public int? ReportingManagerId { get; set; }
        public int? ClientId { get; set; }
        public int? ClientSiteId { get; set; }

        // Identification
        public string NationalId { get; set; }
        public string PassportNo { get; set; }
        public DateTime? PassportExpiryDate { get; set; }
        public string DrivingLicenseNo { get; set; }

        // System Fields
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        // Navigation Properties
        public Company Company { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }
        public Grade Grade { get; set; }
        public Location Location { get; set; }
        public WorkStation WorkStation { get; set; }
        public Employee ReportingManager { get; set; }
        public Client Client { get; set; }
        public ClientSite ClientSite { get; set; }

        public ICollection<Employee> Subordinates { get; set; }
        public ICollection<EmployeeAddress> Addresses { get; set; }
        public ICollection<EmployeeEducation> Educations { get; set; }
        public ICollection<EmployeeExperience> Experiences { get; set; }
        public ICollection<EmployeeReference> References { get; set; }
        public ICollection<EmployeeDocument> Documents { get; set; }
        public ICollection<EmployeeBankAccount> BankAccounts { get; set; }
        public ICollection<EmployeeLifeCycle> LifeCycles { get; set; }
        public EmployeeBackgroundCheck BackgroundCheck { get; set; }
    }
}
