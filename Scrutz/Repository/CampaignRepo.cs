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

        public async Task<IEnumerable<Campaign>> ListAsync()
        {
            return await _context.Campaigns.ToListAsync();
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
