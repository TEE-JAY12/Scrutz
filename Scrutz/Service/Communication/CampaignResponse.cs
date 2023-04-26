using Scrutz.Model;

namespace Scrutz.Service.Communication
{
    public class CampaignResponse : BaseResponse<Campaign>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="campaign">Saved category.</param>
        /// <returns>Response.</returns>
        public CampaignResponse(Campaign campaign) : base(campaign)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CampaignResponse(string message) : base(message)
        { }
    }
}
