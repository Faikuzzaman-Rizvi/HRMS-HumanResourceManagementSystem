namespace HRMS.Models.EmployeeDetails
{
    public class Designation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Level { get; set; } // 1 = Entry, 2 = Junior, 3 = Senior, 4 = Lead, 5 = Manager
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public ICollection<Employee> Employees { get; set; }
    }
}
