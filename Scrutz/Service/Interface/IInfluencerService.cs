using Scrutz.Model;
using Scrutz.Service.Communication;

namespace Scrutz.Service.Interface
{
    public interface IInfluencerService
    {
        Task<IEnumerable<Influencer>> ListAsync();
        Task<InfluencerResponse> AddAsync(Influencer influencer);
        Task<InfluencerResponse> FindByIdAsync(int id);
        Task<InfluencerResponse> UpdateAsync(int id, Influencer influencer);
        Task<InfluencerResponse> DeleteAsync(int id);
    }
}
