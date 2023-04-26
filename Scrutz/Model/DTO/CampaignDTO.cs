using System.ComponentModel.DataAnnotations;

namespace Scrutz.Model.DTO
{
    public class CampaignDTO
    {
        public string? CampaignName { get; set; }
        public string? CampaignDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? RecieveDailyDigest { get; set; }

        [MaxLength(100)]
        public string[]? LinkedKeywords { get; set; }
        public DateTime? DailyDigestTime { get; set; }

        public bool? ActiveCampaign { get; set; }



    }
}
