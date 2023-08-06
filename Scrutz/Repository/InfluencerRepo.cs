using Microsoft.EntityFrameworkCore;
using Scrutz.Data;
using Scrutz.Model;
using Scrutz.Repository.Interface;

namespace Scrutz.Repository
{
    public class InfluencerRepo:BaseRepo, IInfluencerRepo
    {
        public InfluencerRepo(ScrutzContext context) : base(context)
        {

        }

        public async Task AddAsync(Influencer influencer)
        {
            await _context.Influencers.AddAsync(influencer);
        }

        public async Task<Influencer> FindAsync(int id)
        {
            return await _context.Influencers.FindAsync(id);
        }

        public async Task<IEnumerable<Influencer>> ListAsync()
        {
            return await _context.Influencers.ToListAsync();
        }

        public void Remove(Influencer influencer)
        {
            _context.Influencers.Remove(influencer);
        }

        public void Update(Influencer influencer)
        {
            _context.Influencers.Update(influencer);
        }

        public async Task<PagedList<Influencer>> PagedListAsync(PageQuery pageQuery)
        {
            var query = _context.Influencers.AsQueryable();
            int PageSize = 8;

            var pagedList = await Task.FromResult(PagedList<Influencer>.ToPagedList(query, pageQuery.pageNumber, PageSize));

            return pagedList;
        }
    }
}
