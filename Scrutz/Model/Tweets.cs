using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Scrutz.Model
{
    public class Tweets
    {

        
        //[MinLength(30)]
        public string? TweetID { get; set; }

        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        //[MinLength(30)]
        public string UserID { get; set; }

        public Users Users { get; set; }

        //[StringLength(5)]
        public string? Lang { get; set; }

        public DateTime? CreatedAt { get; set; }

        //[StringLength(300)]
        public string? Text { get; set; }

        //[StringLength(10)]
        public string? Sentiment { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal? SentimentScore { get; set; }

        //public TweetMetric TweetMetric { get; set; }
    }
}
