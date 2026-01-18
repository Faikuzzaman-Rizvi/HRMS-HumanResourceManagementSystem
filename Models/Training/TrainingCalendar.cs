namespace HRMS.Models.Training
{
    public class TrainingCalendar
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string Status { get; set; } // Draft, Finalized
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public ICollection<Training> Trainings { get; set; }
    }
}
