namespace HRMS.Models.Payroll
{
    public class BulkUpload
    {
        public int Id { get; set; }
        public string UploadType { get; set; } // Benefits, Deductions, LifeCycle
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public int TotalRecords { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public string Status { get; set; } // In Progress, Completed, Failed
        public string ErrorLogUrl { get; set; }
        public DateTime UploadedDate { get; set; }
        public int UploadedBy { get; set; }
        public DateTime? ProcessedDate { get; set; }
    }
}
