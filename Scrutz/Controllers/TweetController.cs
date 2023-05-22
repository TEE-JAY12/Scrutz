using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrutz.Model;
using Scrutz.Service;
using Scrutz.Service.Interface;

namespace Scrutz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        public TweetController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }


        /// <summary>
        /// Lists all Tweetold Identifed with a campaign Id.
        /// </summary>
        /// <returns>List of campaigns.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Tweets>), 200)]
        public async Task<IEnumerable<Tweets>> GetTweetsById(int id)
        {
            var tweets = await _tweetService.FindByCampaignIdAsync(id);


            return tweets;
        }
    }
}
