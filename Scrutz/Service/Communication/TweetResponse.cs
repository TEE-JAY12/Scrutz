using Scrutz.Model;

namespace Scrutz.Service.Communication
{
    public class TweetResponse: BaseResponse<Tweetold>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="tweet">Saved category.</param>
        /// <returns>Response.</returns>
        public TweetResponse(Tweetold tweet) : base(tweet)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TweetResponse(string message) : base(message)
        { }
    }
}
