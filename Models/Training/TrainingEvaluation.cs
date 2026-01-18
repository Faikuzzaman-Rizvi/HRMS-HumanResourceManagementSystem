using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Training
{
    public class TrainingEvaluation
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public decimal ContentQualityScore { get; set; }
        public decimal TrainerEffectivenessScore { get; set; }
        public decimal RelevanceScore { get; set; }
        public decimal OverallScore { get; set; }
        public string Feedback { get; set; }
        public string Suggestions { get; set; }
        public bool WouldRecommend { get; set; }
        public DateTime EvaluationDate { get; set; }
        // Navigation
        public Training Training { get; set; }
        public Employee Employee { get; set; }
    }
}
