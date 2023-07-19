using Microsoft.EntityFrameworkCore;
using Scrutz.Data;
using Scrutz.Model;
using Scrutz.Repository.Interface;

namespace Scrutz.Repository
{
    public class CampaignRepo : BaseRepo, ICampaignRepo
    {
        public CampaignRepo(ScrutzContext context) : base(context)
        {
        }

        public async Task AddAsync(Campaign campaign)
        {
            await _context.Campaigns.AddAsync(campaign);
        }

        public async Task<Campaign> FindAsync(int id)
        {
            return await _context.Campaigns.FindAsync(id);

        }
        //public async Task<Campaign> FindAsync(int id)
        //{
        //    return await _context.Campaigns
        //        .Include(campaign => campaign.Tweets) // Include the Tweets navigation property
        //        .FirstOrDefaultAsync(campaign => campaign.Id == id);
        //}

        //public async Task<Campaign> FindAsync(int id)
        //{
        //    return await _context.Campaigns
        //        .Include(campaign => campaign.Tweets) // Include the Tweets navigation property
        //            .ThenInclude(tweet => tweet.TweetMetric) // Include the Metrics navigation property of Tweets
        //        .Include(campaign => campaign.Tweets) // Include the Tweets navigation property again
        //            .ThenInclude(tweet => tweet.Users) // Include the User navigation property of Tweets
        //        .FirstOrDefaultAsync(campaign => campaign.Id == id);
        //}

        //public async Task<IEnumerable<Campaign>> ListAsync()
        //{
        //    return await _context.Campaigns.ToListAsync();
        //}

        public async Task<IEnumerable<Campaign>> ListAsync()
        {
            return await _context.Campaigns.ToListAsync();
        }
        public async Task<PagedList<Campaign>> PagedListAsync(PageQuery pageQuery)
        {
            var query = _context.Campaigns.AsQueryable();
            int PageSize = 10;

            var pagedList = await Task.FromResult(PagedList<Campaign>.ToPagedList(query, pageQuery.pageNumber, PageSize));

            return pagedList;
        }

        public async Task<PagedList<Campaign>> PagedListAsyncs(PageQuery pageQuery, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Campaigns.AsQueryable();

            // Apply the date range filter if both start date and end date are provided
            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(c => c.StartDate >= startDate.Value && c.EndDate <= endDate.Value);
            }
            // Apply the start date filter if only the start date is provided
            else if (startDate.HasValue)
            {
                query = query.Where(c => c.StartDate >= startDate.Value);
            }

            int PageSize = 10;
            var pagedList = await Task.FromResult(PagedList<Campaign>.ToPagedList(query, pageQuery.pageNumber, PageSize));

            return pagedList;
        }






        public void Remove(Campaign campaign)
        {
            _context.Campaigns.Remove(campaign);
        }

        public void Update(Campaign campaign)
        {
            _context.Campaigns.Update(campaign);
        }

        
    }
}
