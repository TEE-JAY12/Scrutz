using Microsoft.EntityFrameworkCore;
using Scrutz.Data;
using Scrutz.Model;
using Scrutz.Repository.Interface;

namespace Scrutz.Repository
{
    public class TweetMetricRepo : BaseRepo, ITweetMetricRepo
    {
        public TweetMetricRepo(ScrutzContext context) : base(context)
        {
        }



        //public async Task<TweetMetric> FindByTweetID(string id)
        //{
        //    return _context.TweetMetrics.Where(tweetmetric => tweetmetric.TweetID == id);

        //}

        public async Task<TweetMetric> FindByTweetID(string id)
        {
            return await _context.TweetMetrics.FirstOrDefaultAsync(tweetmetric => tweetmetric.TweetID == id);
        }

    }
}
