using Scrutz.Model;
using Scrutz.Service.Communication;

namespace Scrutz.Service.Interface
{
    public interface ITweetService
    {
        Task<IEnumerable<Tweet>> FindByCampaignIdAsync(int id);
    }
}
