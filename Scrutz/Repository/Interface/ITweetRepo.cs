using Scrutz.Model;

namespace Scrutz.Repository.Interface
{
    public interface ITweetRepo
    {
        
        Task<IEnumerable<Tweet>> FindByCampaignIdAsync(int campaignId);
    }
}
