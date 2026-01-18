using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Training
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Expertise { get; set; }
        public string Qualification { get; set; }
        public int ExperienceYears { get; set; }
        public string TrainerType { get; set; } // Internal, External
        public int? EmployeeId { get; set; } // If internal trainer
        public decimal? RatePerHour { get; set; }
        public string Bio { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public Employee Employee { get; set; }
        public ICollection<Training> Trainings { get; set; }
    }
}
