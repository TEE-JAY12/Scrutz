using Scrutz.Model;

namespace Scrutz.Repository.Interface
{
    public interface IInfluencerRepo
    {
        Task<IEnumerable<Influencer>> ListAsync();
        Task AddAsync(Influencer influencer);
        Task<Influencer> FindAsync(int id);
        void Update(Influencer influencer);
        void Remove(Influencer influencer);
    }
}
