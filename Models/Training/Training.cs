using HRMS.Models.Organization;

namespace HRMS.Models.Training
{
    public class Training
    {
        public int Id { get; set; }
        public string TrainingCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TrainingTypeId { get; set; }
        public int TrainerId { get; set; }
        public int? TrainingCalendarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int DurationHours { get; set; }
        public string Venue { get; set; }
        public int? LocationId { get; set; }
        public string TrainingMode { get; set; } // Online, Offline, Hybrid
        public string MeetingLink { get; set; }
        public int MaxParticipants { get; set; }
        public decimal? Budget { get; set; }
        public string Status { get; set; } // Scheduled, Ongoing, Completed, Cancelled
        public string Materials { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        // Navigation
        public TrainingType TrainingType { get; set; }
        public Trainer Trainer { get; set; }
        public Location Location { get; set; }
        public TrainingCalendar Calendar { get; set; }
        public ICollection<TrainingAssignment> Assignments { get; set; }
        public ICollection<TrainingAttendance> Attendances { get; set; }
        public ICollection<TrainingEvaluation> Evaluations { get; set; }
    }
}
