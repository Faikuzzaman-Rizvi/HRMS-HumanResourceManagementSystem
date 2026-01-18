using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Training
{
    public class TrainingAssignment
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AssignedDate { get; set; }
        public bool IsMandatory { get; set; }
        public string Status { get; set; } // Assigned, Confirmed, Completed, Cancelled, No Show
        public string Remarks { get; set; }
        public int AssignedBy { get; set; }
        // Navigation
        public Training Training { get; set; }
        public Employee Employee { get; set; }
    }
}
