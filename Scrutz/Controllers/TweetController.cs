using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Scrutz.Model;
using Scrutz.Service;
using Scrutz.Service.Interface;
using System.Collections;

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
        /// Lists all Tweet Identifed with a campaign Id.
        /// </summary>
        /// <returns>List of campaigns.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Tweets>), 200)]
        public async Task<IEnumerable<Tweets>> GetTweetsById(int id)
        {
            var tweets = await _tweetService.FindByCampaignIdAsync(id);


            return tweets;
        }

   
        /// <summary>
        /// Lists all TweetInformation Identifed with a campaign Id .
        /// </summary>
        /// <returns>List of campaigns.</returns>
        [HttpGet("TweetInformation/{id}")]
        [ProducesResponseType(typeof(ArrayList), 200)]
        public async Task<ActionResult<ArrayList>> GetTweetsInformationById(int id)
        {
            var tweets = await _tweetService.FindByCampaignIdAsyncs(id);


            return tweets;
        }

        /// <summary>
        /// Lists all tweets by campaignId Paged.
        /// </summary>
        /// <returns>List of Tweets.</returns>
        [HttpGet("PagedTweetsByCampaignId")]
        [ProducesResponseType(typeof(PagedList<Campaign>), 200)]
        public async Task<PagedList<Tweets>> GetCampaigns([FromQuery] PageQuery pageQuery , int id)
        {
            PagedList<Tweets> campaigns;

            if (id > 0)
            {
                //campaigns = await _tweetService.PagedListAsync();
                campaigns = await _tweetService.PagedListAsync(pageQuery, id);
            }
            else
            {
                campaigns = await _tweetService.PagedListAsync();
                //campaigns = await _tweetService.PagedListAsync(pageQuery, id);
            }
            var metadata = new
            {
                campaigns.TotalCount,
                campaigns.PageSize,
                campaigns.CurrentPage,
                campaigns.TotalPages,
                campaigns.HasNext,
                campaigns.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));


            return campaigns;
        }


        ///// <summary>
        ///// Lists all Tweets Paged.
        ///// </summary>
        ///// <returns>List of campaigns.</returns>
        //[HttpGet("PagedTweets")]
        //[ProducesResponseType(typeof(PagedList<Tweets>), 200)]
        //public async Task<PagedList<Tweets>> GetCampaigns()
        //{
        //    var campaigns = await _tweetService.PagedListAsync();

        //    var metadata = new
        //    {
        //        campaigns.TotalCount,
        //        campaigns.PageSize,
        //        campaigns.CurrentPage,
        //        campaigns.TotalPages,
        //        campaigns.HasNext,
        //        campaigns.HasPrevious
        //    };
        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));


        //    return campaigns;
        //}


    }
}
