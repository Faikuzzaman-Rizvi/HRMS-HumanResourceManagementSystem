namespace HRMS.Models.Training
{
    public class TrainingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } // Technical, Soft Skills, Compliance, Safety
        public bool IsActive { get; set; }

        // Navigation
        public ICollection<Training> Trainings { get; set; }
    }
}
