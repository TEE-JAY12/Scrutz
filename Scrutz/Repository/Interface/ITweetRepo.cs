using Scrutz.Model;

namespace Scrutz.Repository.Interface
{
    public interface ITweetRepo
    {
        
        Task<IEnumerable<Tweets>> FindByCampaignIdAsync(int campaignId);
    }
}
