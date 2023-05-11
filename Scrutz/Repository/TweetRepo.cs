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

        public async Task<IEnumerable<Tweet>> FindByCampaignIdAsync(int campaignId)
        {
            return _context.Tweets.Where(tweet => tweet.CampaignId == campaignId).ToList();
        }

    }
}
