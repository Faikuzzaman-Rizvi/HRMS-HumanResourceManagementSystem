using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Recruitment
{
    public class InterviewEvaluation
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public decimal TechnicalScore { get; set; }
        public decimal CommunicationScore { get; set; }
        public decimal AttitudeScore { get; set; }
        public decimal OverallScore { get; set; }
        public string Recommendation { get; set; } // Selected, Rejected, On Hold, Second Round
        public string Feedback { get; set; }
        public decimal? OfferedSalary { get; set; }
        public DateTime EvaluationDate { get; set; }
        public int EvaluatedBy { get; set; }

        // Navigation
        public Interview Interview { get; set; }
        public Employee Evaluator { get; set; }
    }
}
