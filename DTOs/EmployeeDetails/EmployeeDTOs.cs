namespace HRMS.DTOs.EmployeeDetails
{
    public class EmployeeDTOs
    {
        public class EmployeeDTO
        {
            public int Id { get; set; }
            public string EmployeeCode { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Gender { get; set; }
            public string CompanyName { get; set; }
            public string DepartmentName { get; set; }
            public string DesignationTitle { get; set; }
            public string GradeName { get; set; }
            public string LocationName { get; set; }
            public string EmploymentStatus { get; set; }
            public string EmploymentType { get; set; }
            public DateTime JoiningDate { get; set; }
            public string ReportingManagerName { get; set; }
            public bool IsActive { get; set; }
        }

        public class EmployeeDetailDTO
        {
            public int Id { get; set; }
            public string EmployeeCode { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string PersonalEmail { get; set; }
            public string Phone { get; set; }
            public string EmergencyContact { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string BloodGroup { get; set; }
            public string MaritalStatus { get; set; }
            public string ProfilePictureUrl { get; set; }

            // Employment
            public DateTime JoiningDate { get; set; }
            public DateTime? ProbationEndDate { get; set; }
            public DateTime? ConfirmationDate { get; set; }
            public string EmploymentStatus { get; set; }
            public string EmploymentType { get; set; }

            // Organization
            public int CompanyId { get; set; }
            public string CompanyName { get; set; }
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }
            public int DesignationId { get; set; }
            public string DesignationTitle { get; set; }
            public int GradeId { get; set; }
            public string GradeName { get; set; }
            public int? LocationId { get; set; }
            public string LocationName { get; set; }
            public int? ReportingManagerId { get; set; }
            public string ReportingManagerName { get; set; }

            // Identification
            public string NationalId { get; set; }
            public string PassportNo { get; set; }
            public DateTime? PassportExpiryDate { get; set; }

            // Related Data
            public List<EmployeeAddressDTO> Addresses { get; set; }
            public List<EmployeeEducationDTO> Educations { get; set; }
            public List<EmployeeExperienceDTO> Experiences { get; set; }
            public List<EmployeeBankAccountDTO> BankAccounts { get; set; }

            public bool IsActive { get; set; }
        }

        public class CreateEmployeeDTO
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PersonalEmail { get; set; }
            public string Phone { get; set; }
            public string EmergencyContact { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string BloodGroup { get; set; }
            public string MaritalStatus { get; set; }

            // Employment
            public DateTime JoiningDate { get; set; }
            public string EmploymentType { get; set; }

            // Organization
            public int CompanyId { get; set; }
            public int DepartmentId { get; set; }
            public int DesignationId { get; set; }
            public int GradeId { get; set; }
            public int? LocationId { get; set; }
            public int? ReportingManagerId { get; set; }

            // Identification
            public string NationalId { get; set; }
            public string PassportNo { get; set; }
        }

        public class UpdateEmployeeDTO
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string PersonalEmail { get; set; }
            public string Phone { get; set; }
            public string EmergencyContact { get; set; }
            public string BloodGroup { get; set; }
            public string MaritalStatus { get; set; }
            public int? LocationId { get; set; }
            public int? ReportingManagerId { get; set; }
            public bool IsActive { get; set; }
        }

        public class EmployeeAddressDTO
        {
            public int Id { get; set; }
            public int EmployeeId { get; set; }
            public string AddressType { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string ZipCode { get; set; }
            public bool IsPrimary { get; set; }
        }

        public class CreateEmployeeAddressDTO
        {
            public string AddressType { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string ZipCode { get; set; }
            public bool IsPrimary { get; set; }
        }

        public class EmployeeEducationDTO
        {
            public int Id { get; set; }
            public string Degree { get; set; }
            public string Major { get; set; }
            public string Institution { get; set; }
            public string Board { get; set; }
            public string Country { get; set; }
            public int PassingYear { get; set; }
            public string Result { get; set; }
        }

        public class CreateEmployeeEducationDTO
        {
            public string Degree { get; set; }
            public string Major { get; set; }
            public string Institution { get; set; }
            public string Board { get; set; }
            public string Country { get; set; }
            public int PassingYear { get; set; }
            public string Result { get; set; }
        }

        public class EmployeeExperienceDTO
        {
            public int Id { get; set; }
            public string CompanyName { get; set; }
            public string Designation { get; set; }
            public string Department { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime? ToDate { get; set; }
            public bool IsCurrentJob { get; set; }
            public string JobResponsibilities { get; set; }
        }

        public class CreateEmployeeExperienceDTO
        {
            public string CompanyName { get; set; }
            public string Designation { get; set; }
            public string Department { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime? ToDate { get; set; }
            public bool IsCurrentJob { get; set; }
            public string JobResponsibilities { get; set; }
            public string ReasonForLeaving { get; set; }
        }

        public class EmployeeBankAccountDTO
        {
            public int Id { get; set; }
            public string BankName { get; set; }
            public string BranchName { get; set; }
            public string AccountNumber { get; set; }
            public string AccountTitle { get; set; }
            public string AccountType { get; set; }
            public bool IsPrimary { get; set; }
        }

        public class CreateEmployeeBankAccountDTO
        {
            public int BankId { get; set; }
            public int BranchId { get; set; }
            public string AccountNumber { get; set; }
            public string AccountTitle { get; set; }
            public string AccountType { get; set; }
            public bool IsPrimary { get; set; }
        }
    }
}
