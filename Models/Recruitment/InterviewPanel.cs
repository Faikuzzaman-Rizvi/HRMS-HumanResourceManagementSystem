using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Recruitment
{
    public class InterviewPanel
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public int InterviewerId { get; set; }
        public string Role { get; set; } // Primary, Secondary

        // Navigation
        public Interview Interview { get; set; }
        public Employee Interviewer { get; set; }
    }
}
