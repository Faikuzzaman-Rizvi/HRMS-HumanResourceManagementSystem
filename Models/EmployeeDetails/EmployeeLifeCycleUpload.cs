namespace HRMS.Models.EmployeeDetails
{
    public class EmployeeLifeCycleUpload
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int TotalRecords { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public string Status { get; set; }
        public DateTime UploadedDate { get; set; }
        public int UploadedBy { get; set; }
        public string ErrorLog { get; set; }
    }
}
