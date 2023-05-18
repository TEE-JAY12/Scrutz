using Scrutz.Model;
using Scrutz.Repository.Interface;
using Scrutz.Service.Communication;
using Scrutz.Service.Interface;

namespace Scrutz.Service
{
    public class InfluencerService:IInfluencerService
    {
        private readonly IInfluencerRepo _influncerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InfluencerService(IInfluencerRepo iinfluncerRepo, IUnitOfWork unitOfWork)
        {
            _influncerRepository = iinfluncerRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<InfluencerResponse> DeleteAsync(int id)
        {
            var existinginfluencer = await _influncerRepository.FindAsync(id);

            if (existinginfluencer == null)
                return new InfluencerResponse("Influencer not found.");

            try
            {
                _influncerRepository.Remove(existinginfluencer);
                await _unitOfWork.CompleteAsync();

                return new InfluencerResponse(existinginfluencer);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new InfluencerResponse($"An error occurred when deleting the influencer: {ex.Message}");
            }
        }



        //Task<IEnumerable<Campaign>> ListAsync();
        //Task AddAsync(Campaign campaign);
        //Task<Campaign> FindByIdAsync(int id);
        //void Update(Campaign campaign);
        //void Remove(Campaign campaign);

        public async Task<IEnumerable<Influencer>> ListAsync()
        {

            var influencer = await _influncerRepository.ListAsync();

            return influencer;
        }

        public async Task<InfluencerResponse> AddAsync(Influencer influencer)
        {
            try
            {
                await _influncerRepository.AddAsync(influencer);
                await _unitOfWork.CompleteAsync();

                return new InfluencerResponse(influencer);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new InfluencerResponse($"An error occurred when saving the Influencer: {ex.Message}");
            }
        }

        public async Task<InfluencerResponse> UpdateAsync(int id, Influencer influencer)
        {
            var existinginfluencer = await _influncerRepository.FindAsync(id);
            if (existinginfluencer == null)
            {
                return new InfluencerResponse("Influencer not found");
            }

            existinginfluencer.NameOfInfluencer = influencer.NameOfInfluencer;
            existinginfluencer.EmailAddress = influencer.EmailAddress;
            existinginfluencer.Role = influencer.Role;
            existinginfluencer.CampaignId = influencer.CampaignId;
            existinginfluencer.InstagramHandle = influencer.InstagramHandle;
            existinginfluencer.TwitterHandle = influencer.TwitterHandle;
            existinginfluencer.FacebookHanlde = influencer.FacebookHanlde;
            existinginfluencer.LinkedKeywords = influencer.LinkedKeywords;


            try
            {
                await _unitOfWork.CompleteAsync();
                return new InfluencerResponse(existinginfluencer);
            }
            catch (Exception ex)
            {
                return new InfluencerResponse($"An error occurred when updating the influencer: {ex.Message}");
            }


        }

        public async Task<InfluencerResponse> FindByIdAsync(int id)
        {
            var existinginfluencer = await _influncerRepository.FindAsync(id);
            if (existinginfluencer == null)
            {
                return new InfluencerResponse("Influencer not found.");
            }

            return new InfluencerResponse(existinginfluencer);

        }
    }
}
