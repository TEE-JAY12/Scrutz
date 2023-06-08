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

        //public async Task<IEnumerable<Tweets>> FindByCampaignIdAsync(int campaignId)
        //{
        //    return _context.Tweet.Where(tweet => tweet.CampaignId == campaignId).ToList();
        //}

        public async Task<IEnumerable<Tweets>> FindByCampaignIdAsync(int campaignId)
        {
            return await _context.Tweet
                //.Include(tweet => tweet.Campaign)
                .Include(tweet => tweet.Users)
                .Include(tweet => tweet.TweetMetric)
                .Where(tweet => tweet.CampaignId == campaignId)
                .ToListAsync();
        }


        public async Task<PagedList<Tweets>> FindByCampaignIdPaged(PageQuery pageQuery, int campaignId)
        {
            var query = _context.Tweet
                .Include(tweet => tweet.Users)
                .Include(tweet => tweet.TweetMetric)
                .Where(tweet => tweet.CampaignId == campaignId)
                .AsQueryable();

            int PageSize = 10;

            //var pagedList = await Task.FromResult(PagedList<Tweets>.ToPagedList(query, pageQuery.pageNumber, pageQuery.pageSize));
            var pagedList = await Task.FromResult(PagedList<Tweets>.ToPagedList(query, pageQuery.pageNumber, PageSize));
            return pagedList;
        }

        public async Task<PagedList<Tweets>> PagedListAsync()
        {
            var query = _context.Tweet
                .Include(tweet => tweet.Users)
                .Include(tweet => tweet.TweetMetric)
                .AsQueryable();

            int PageNumber = 1;
            int PageSize = 10;

            var pagedList = await Task.FromResult(PagedList<Tweets>.ToPagedList(query, PageNumber, PageSize));

            return pagedList;
        }

    }
}
