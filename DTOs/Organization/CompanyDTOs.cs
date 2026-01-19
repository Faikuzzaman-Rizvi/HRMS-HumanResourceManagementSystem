namespace HRMS.DTOs.Organization
{
    public class CompanyDTOs
    {
        public class CompanyDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public string LegalName { get; set; }
            public string RegistrationNumber { get; set; }
            public string TaxIdentificationNumber { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Website { get; set; }
            public string LogoUrl { get; set; }
            public DateTime EstablishedDate { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class CreateCompanyDTO
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public string LegalName { get; set; }
            public string RegistrationNumber { get; set; }
            public string TaxIdentificationNumber { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Website { get; set; }
            public DateTime EstablishedDate { get; set; }
        }

        public class UpdateCompanyDTO
        {
            public string Name { get; set; }
            public string LegalName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Website { get; set; }
            public bool IsActive { get; set; }
        }

        public class DepartmentDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public int CompanyId { get; set; }
            public string CompanyName { get; set; }
            public int? LocationId { get; set; }
            public string LocationName { get; set; }
            public int? ParentDepartmentId { get; set; }
            public string ParentDepartmentName { get; set; }
            public int? ManagerEmployeeId { get; set; }
            public string ManagerName { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
        }

        public class CreateDepartmentDTO
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public int CompanyId { get; set; }
            public int? LocationId { get; set; }
            public int? ParentDepartmentId { get; set; }
            public int? ManagerEmployeeId { get; set; }
            public string Description { get; set; }
        }

        public class UpdateDepartmentDTO
        {
            public string Name { get; set; }
            public int? LocationId { get; set; }
            public int? ParentDepartmentId { get; set; }
            public int? ManagerEmployeeId { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
        }

        public class LocationDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public int CompanyId { get; set; }
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string ZipCode { get; set; }
            public string Phone { get; set; }
            public bool IsHeadOffice { get; set; }
            public bool IsActive { get; set; }
        }

        public class CreateLocationDTO
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public int CompanyId { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string ZipCode { get; set; }
            public string Phone { get; set; }
            public bool IsHeadOffice { get; set; }
        }

        public class DesignationDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Code { get; set; }
            public int Level { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
        }

        public class CreateDesignationDTO
        {
            public string Title { get; set; }
            public string Code { get; set; }
            public int Level { get; set; }
            public string Description { get; set; }
        }

        public class GradeDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public int Level { get; set; }
            public decimal MinSalary { get; set; }
            public decimal MaxSalary { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
        }

        public class CreateGradeDTO
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public int Level { get; set; }
            public decimal MinSalary { get; set; }
            public decimal MaxSalary { get; set; }
            public string Description { get; set; }
        }
    }
}
