﻿using Microsoft.EntityFrameworkCore;
using Scrutz.Data;
using Scrutz.Model;
using Scrutz.Repository.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<PagedList<Campaign>> PagedListAsyncs(PageQuery pageQuery, DateTime? startDate, DateTime? endDate, ActiveStatus? campaignStatus)
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


            // Apply the campaign status filter if the status is provided
            if (campaignStatus.HasValue)
            {
                query = query.Where(c => c.CampaignStatus == campaignStatus.Value);
            }

            int PageSize = 8;
            var pagedList = await Task.FromResult(PagedList<Campaign>.ToPagedList(query, pageQuery.pageNumber, PageSize));

            return pagedList;
        }

        //This is the roboust repo for the returing paged campaigns.
        //Contains filtering by date and Search
        public async Task<PagedList<Campaign>> PagedList(PageQuery pageQuery, DateTime? startDate, DateTime? endDate, ActiveStatus? campaignStatus, string searchTerm)
        {
            var query = _context.Campaigns.AsQueryable();


            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Split the search term into individual words
                var searchTerms = searchTerm.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Apply the search filter for each word in the search term
                foreach (var term in searchTerms)
                {
                    // Search for campaigns that have the term in their Title or Description (case-insensitive)
                    
                    //query = query.Where(c => c.CampaignName.ToLower().Contains(term.ToLower()) || c.CampaignDescription.ToLower().Contains(term.ToLower()) || c.LinkedKeywords.Contains(term.ToLower()));
                    query = query.Where(c => c.CampaignName.ToLower() == term.ToLower() || c.CampaignDescription.ToLower() == term.ToLower() || c.LinkedKeywords.Contains(term.ToLower()));
                   
                }
            }

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

            // Apply the campaign status filter if the status is provided
            if (campaignStatus.HasValue)
            {
                query = query.Where(c => c.CampaignStatus == campaignStatus.Value);
            }

            // Apply the search filter if a search term is provided
            //if (!string.IsNullOrEmpty(searchTerm))
            //{
            //    query = query.Where(c => c.CampaignName.Contains(searchTerm) || c.CampaignDescription.Contains(searchTerm) || c.LinkedKeywords.Contains(searchTerm));
            //}



            int PageSize = 8;
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

        //public async Task<IEnumerable<Tweets>> FindByCampaignIdAsync(int campaignId)
        //{
        //    return _context.Tweet.Where(tweet => tweet.CampaignId == campaignId).ToList();
        //}


        public async Task<int> GetCampaignCountByStatusAsync(ActiveStatus? status)
        {
            //if (status != null)
            //{
            //    return await _context.Campaigns.CountAsync(campaign => campaign.CampaignStatus == status);
            //}
            //else
            //{
            //    return await _context.Campaigns.CountAsync();
            //}

            return await _context.Campaigns.CountAsync(campaign => campaign.CampaignStatus == status);
        }

        public async Task<int> GetCampaignCountByStatusAsync()
        {
             return await _context.Campaigns.CountAsync();
            
        }
    }
}
