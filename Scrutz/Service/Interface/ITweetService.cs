using Scrutz.Model;
using Scrutz.Service.Communication;
using System.Collections;

namespace Scrutz.Service.Interface
{
    public interface ITweetService
    {
        Task<IEnumerable<Tweets>> FindByCampaignIdAsync(int id);

        Task<ArrayList> FindByCampaignIdAsyncs(int id);

        Task<PagedList<Tweets>> PagedListAsync(PageQuery pageQuery, int campaignId);

        Task<PagedList<Tweets>> PagedListAsync();

        Task<PagedList<Tweets>> PagedListAsyncs(PageQuery pageQuery, int campaignId, DateTime? startDate, DateTime? endDate);
    }
}
