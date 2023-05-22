using System.ComponentModel.DataAnnotations;

namespace Scrutz.Model
{
    public class Campaign
    {
        public int Id { get; set; }
        public string? CampaignName { get; set;}
        public string? CampaignDescription { get; set;}
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
        public bool? RecieveDailyDigest { get; set; }

        [MaxLength(100)]
        public string[]? LinkedKeywords { get; set; }
        public string? DailyDigestTime { get; set; }

        public ActiveStatus? CampaignStatus { get; set; }

        public ICollection<Tweets> Tweets { get; set; }

        public ICollection<Influencer> Influencers { get; set; }

    }
}
