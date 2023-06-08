namespace Scrutz.Model
{
    public class TweetMetric
    {
        
        //public int? Id { get; set; }

        public string TweetID { get; set; }
        public Tweets Tweets { get; set; }

        public int? ImpressionCount { get; set; }
        public int? LikeCount { get; set; }
        public int? QuoteCount { get; set; }
        public int? ReplyCount { get; set; }
        public int? RetweetCount { get; set; }
    }
}
