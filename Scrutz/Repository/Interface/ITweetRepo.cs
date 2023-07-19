using Scrutz.Model;

namespace Scrutz.Repository.Interface
{
    public interface ITweetRepo
    {
        
        Task<IEnumerable<Tweets>> FindByCampaignIdAsync(int campaignId);

        Task<PagedList<Tweets>> FindByCampaignIdPaged(PageQuery pageQuery, int campaignId);

        Task<PagedList<Tweets>> PagedListAsync();

        Task<PagedList<Tweets>> FindByCampaignIdPageds(PageQuery pageQuery, int campaignId, DateTime? startDate, DateTime? endDate);

    }
}
