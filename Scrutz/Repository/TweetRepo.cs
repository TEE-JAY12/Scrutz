using Microsoft.EntityFrameworkCore;
using Scrutz.Data;
using Scrutz.Model;
using Scrutz.Repository.Interface;

namespace Scrutz.Repository
{
    public class TweetRepo : BaseRepo, ITweetRepo
    {
        public TweetRepo(ScrutzContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tweets>> FindByCampaignIdAsync(int campaignId)
        {
            return _context.Tweet.Where(tweet => tweet.CampaignId == campaignId).ToList();
        }

    }
}
