using System.ComponentModel.DataAnnotations;

namespace Scrutz.Model
{
    public class Influencer
    {
        public int Id {get; set;}
        public String? NameOfInfluencer{get; set;}
        public String? EmailAddress { get; set; }
        public String? Role { get; set; }

        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public String? InstagramHandle { get; set;}
        public String? TwitterHandle { get; set;}
        public String? FacebookHanlde { get; set; }

        [MaxLength(100)]
        public string[]? LinkedKeywords { get; set; }

        [MaxLength(100)]
        public string[]? SocialPlatforms { get; set; }

    }
}
