using HRMS.Models.Organization;

namespace HRMS.Models.TimeAttendance
{
    public class Holiday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } // Public, Optional
        public string Description { get; set; }
        public int? LocationId { get; set; }
        public bool IsActive { get; set; }

        // Navigation
        public Location Location { get; set; }
    }
}
