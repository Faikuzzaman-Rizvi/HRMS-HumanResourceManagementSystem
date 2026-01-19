using HRMS.Models.Common;

namespace HRMS.Models.Organization
{
    public class ClientRemark : BaseEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Remark { get; set; }
        public string RemarkType { get; set; } // General, Issue, Feedback, Complaint
        public DateTime RemarkDate { get; set; }
        public int CreatedBy { get; set; }

        // Navigation
        public Client Client { get; set; }
    }
}
