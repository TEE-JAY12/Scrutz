using Microsoft.EntityFrameworkCore;
using Scrutz.Model;
using Scrutz.Repository.Interface;
using Scrutz.Service.Communication;
using Scrutz.Service.Interface;

namespace Scrutz.Service
{
    public class CampaignService:ICampaignService
    {
        private readonly ICampaignRepo _campaignRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CampaignService(ICampaignRepo icampaignRepo, IUnitOfWork unitOfWork)
        {
            _campaignRepository = icampaignRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<CampaignResponse> DeleteAsync(int id)
        {
            var existingcampaign = await _campaignRepository.FindAsync(id);

            if (existingcampaign == null) 
                return new CampaignResponse("Campaign not found.");

            try
            {
                _campaignRepository.Remove(existingcampaign);
                await _unitOfWork.CompleteAsync();

                return new CampaignResponse(existingcampaign);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CampaignResponse($"An error occurred when deleting the campaign: {ex.Message}");
            }
        }



        //Task<IEnumerable<Campaign>> ListAsync();
        //Task AddAsync(Campaign campaign);
        //Task<Campaign> FindByIdAsync(int id);
        //void Update(Campaign campaign);
        //void Remove(Campaign campaign);
        public async Task<PagedList<Campaign>> PagedListAsync(PageQuery pageQuery)
        {

            var campaign = await _campaignRepository.PagedListAsync(pageQuery);

            return campaign;
        }


        public async Task<IEnumerable<Campaign>> ListAsync()
        {

            var campaign = await _campaignRepository.ListAsync();

            return campaign;
        }

        public async Task<CampaignResponse> AddAsync(Campaign campaign)
        {
            try
            {
                await _campaignRepository.AddAsync(campaign);
                await _unitOfWork.CompleteAsync();

                return new CampaignResponse(campaign);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CampaignResponse($"An error occurred when saving the campaign: {ex.Message}");
            }
        }

        public async Task<CampaignResponse> UpdateAsync(int id, Campaign campaign)
        {
            var existingcampaign = await _campaignRepository.FindAsync(id);
            if (existingcampaign == null)
            {
                return new CampaignResponse("Campaign not found");
            }
            //_context.Entry(campaign).State = EntityState.Modified;
            existingcampaign.CampaignName = campaign.CampaignName;
            existingcampaign.CampaignDescription = campaign.CampaignDescription;
            existingcampaign.StartDate = campaign.StartDate;
            existingcampaign.EndDate = campaign.EndDate;
            existingcampaign.RecieveDailyDigest = campaign.RecieveDailyDigest;
            existingcampaign.LinkedKeywords = campaign.LinkedKeywords;
            existingcampaign.DailyDigestTime = campaign.DailyDigestTime;
            //existingcampaign.ActiveCampaign = campaign.ActiveCampaign;

            try
            {
                await _unitOfWork.CompleteAsync();
                return new CampaignResponse(existingcampaign);
            }
            catch(Exception ex)
            {
                return new CampaignResponse($"An error occurred when updating the campaign: {ex.Message}");
            }
           

        }

        public async Task<CampaignResponse> FindByIdAsync(int id)
        {
            var existingcampaign = await _campaignRepository.FindAsync(id);
            if (existingcampaign == null)
            {
                return new CampaignResponse("Campaign not found.");
            }

            return new CampaignResponse(existingcampaign);
           
        }

        public async Task<CampaignResponse> UpdateActiveStatus(int id,ActiveStatus activeStatus)
        {
            var existingcampaign = await _campaignRepository.FindAsync(id);
            if (existingcampaign == null)
            {
                return new CampaignResponse("Campaign not found");
            }
            existingcampaign.CampaignStatus = activeStatus;
            try
            {
                await _unitOfWork.CompleteAsync();
                return new CampaignResponse(existingcampaign);
            }
            catch (Exception ex)
            {
                return new CampaignResponse($"An error occurred when updating the campaign: {ex.Message}");
            }

            
        }

    }
}
