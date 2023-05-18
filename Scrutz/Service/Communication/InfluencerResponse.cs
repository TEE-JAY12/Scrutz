using Scrutz.Model;

namespace Scrutz.Service.Communication
{
    public class InfluencerResponse: BaseResponse<Influencer>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="influencer">Saved category.</param>
        /// <returns>Response.</returns>
        public InfluencerResponse(Influencer influencer) : base(influencer)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public InfluencerResponse(string message) : base(message)
        { }
    }
}
