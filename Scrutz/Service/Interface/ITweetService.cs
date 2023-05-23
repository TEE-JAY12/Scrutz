using Scrutz.Model;
using Scrutz.Service.Communication;
using System.Collections;

namespace Scrutz.Service.Interface
{
    public interface ITweetService
    {
        Task<IEnumerable<Tweets>> FindByCampaignIdAsync(int id);

        Task<ArrayList> FindByCampaignIdAsyncs(int id);
    }
}
