using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Organization
{
    public class Company
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
        public bool IsActive { get; set; }
        public DateTime EstablishedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public ICollection<Location> Locations { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
