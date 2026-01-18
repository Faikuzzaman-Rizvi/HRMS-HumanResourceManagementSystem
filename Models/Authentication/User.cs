using HRMS.Models.EmployeeDetails;
namespace HRMS.Models.Authentication
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        // Navigation
        public ICollection<UserRole> UserRoles { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
