using Scrutz.Model;
using Scrutz.Service.Communication;

namespace Scrutz.Service.Interface
{
    public interface ICampaignService
    {
        Task<IEnumerable<Campaign>> ListAsync();
        Task<CampaignResponse> AddAsync(Campaign campaign);
        Task<CampaignResponse> FindByIdAsync(int id);
        Task<CampaignResponse> UpdateAsync(int id, Campaign campaign);
        Task<CampaignResponse> DeleteAsync(int id);
        Task<CampaignResponse> UpdateActiveStatus(int id,ActiveStatus activeStatus);
    }
}
