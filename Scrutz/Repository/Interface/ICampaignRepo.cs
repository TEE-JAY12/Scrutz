﻿using Scrutz.Model;

namespace Scrutz.Repository.Interface
{
    public interface ICampaignRepo
    {
        Task<PagedList<Campaign>> PagedListAsync(PageQuery pageQuery);
        //IEnumerable<Owner> GetOwners(OwnerParameters ownerParameters);
        Task<IEnumerable<Campaign>> ListAsync();
        Task AddAsync(Campaign campaign);
        Task<Campaign> FindAsync(int id);
        void Update(Campaign campaign);
        void Remove(Campaign campaign);

        Task<PagedList<Campaign>> PagedListAsyncs(PageQuery pageQuery, DateTime? startDate, DateTime? endDate);
    }
}
