using HRMS.Models.EmployeeDetails;

namespace HRMS.Models.Recruitment
{
    public class RequisitionApproval
    {
        public int Id { get; set; }
        public int RequisitionId { get; set; }
        public int ApprovalLevel { get; set; } // 1, 2, 3 (Multi-level approval)
        public int ApproverId { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public string Comments { get; set; }
        public DateTime? ApprovalDate { get; set; }

        // Navigation
        public JobRequisition Requisition { get; set; }
        public Employee Approver { get; set; }
    }
}

