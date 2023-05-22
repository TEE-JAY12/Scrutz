using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrutz.Model
{
    public class Tweetold
    {
        [Key] // Specify the primary key attribute
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public string? ScreenName { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set;}
        public string TweetId { get; set; }
        public string UserName { get; set; }
        public string UserLocation { get; set; }
        public string UserDescription { get; set; }
        public string UserVerified { get; set; }
        public DateTime? Date { get; set; }

        public string Tweets { get; set;}
        public string TweetedFrom { get; set; }

        public string RetweetCount { get; set; }

        public int? Likes { get; set; }

        public int? FollowersCount { get; set; }
        public string? KeyPhrase { get; set; }

        public string Sentiments { get; set; }




    }
}
