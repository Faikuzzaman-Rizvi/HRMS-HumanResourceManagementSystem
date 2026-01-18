namespace HRMS.Models.Recruitment
{
    public class Interview
    {
        public int Id { get; set; }
        public string InterviewCode { get; set; }
        public int RequisitionId { get; set; }
        public int? CVPoolId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidatePhone { get; set; }
        public string CVFileUrl { get; set; }
        public DateTime InterviewDate { get; set; }
        public TimeSpan InterviewTime { get; set; }
        public string InterviewType { get; set; } // Phone, Video, In-Person, Technical, HR
        public string InterviewMode { get; set; } // Online, Offline
        public string Venue { get; set; }
        public string MeetingLink { get; set; }
        public string Status { get; set; } // Scheduled, Completed, Cancelled, No Show
        public string Remarks { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public JobRequisition Requisition { get; set; }
        public CVPool CVPool { get; set; }
        public ICollection<InterviewPanel> InterviewPanels { get; set; }
        public InterviewEvaluation Evaluation { get; set; }
    }
}
