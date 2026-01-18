using HRMS.Models.Organization;

namespace HRMS.Models.Recruitment
{
    public class CandidateRelocation
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public decimal RelocationAllowance { get; set; }
        public bool AccommodationProvided { get; set; }
        public string Status { get; set; } // Offered, Accepted, Rejected
        public DateTime OfferDate { get; set; }
        public DateTime? ResponseDate { get; set; }

        // Navigation
        public Interview Interview { get; set; }
        public Location FromLocation { get; set; }
        public Location ToLocation { get; set; }
    }
}
