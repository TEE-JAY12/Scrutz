using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrutz.Model.DTO;
using Scrutz.Model;
using Scrutz.Resource;
using Scrutz.Service.Interface;
using Scrutz.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace Scrutz.Controllers
{
    [Authorize]
    [RequiredScope("Access_as_user")]
    [Route("api/[controller]")]
    [ApiController]
    public class InfluencerController : ControllerBase
    {
        private readonly IInfluencerService _influencerService;
        private readonly IMapper _mapper;
        public InfluencerController(IInfluencerService influencerService, IMapper mapper)
        {
            _influencerService = influencerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all Influencers.
        /// </summary>
        /// <returns>List of Influencers.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Influencer>), 200)]
        public async Task<IEnumerable<Influencer>> GetInfluencer()
        {
            var influencer = await _influencerService.ListAsync();


            return influencer;
        }

        /// <summary>
        /// Saves a new influencer.
        /// </summary>
        /// <param name="influencer">Campaign data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Influencer), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostInfluencer([FromBody] InfluencerDTO influencerDTO)
        {
            //var category = _mapper.Map<InfluencerDTO, Influencer>(influencerDTO);
            var influencer = new Influencer
            {
                NameOfInfluencer = influencerDTO.NameOfInfluencer,
                EmailAddress = influencerDTO.EmailAddress,
                Role = influencerDTO.Role,
                CampaignId = influencerDTO.CampaignId,
                InstagramHandle = influencerDTO.InstagramHandle,
                TwitterHandle = influencerDTO.TwitterHandle,
                FacebookHanlde = influencerDTO.FacebookHanlde,
                LinkedKeywords = influencerDTO.LinkedKeywords
            };
            var result = await _influencerService.AddAsync(influencer);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            //var campaignResource = result.Resource;
            //return Ok(campaignResource);
            var influencerResource = result.Resource;
            return CreatedAtAction(nameof(GetCampaign), new { id = influencerResource.Id }, influencerResource);
        }

        /// <summary>
        /// Updates an existing influencer according to an identifier.
        /// </summary>
        /// <param name="id">Influencer identifier.</param>
        /// <param name="influencer">Updated Influencer data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Influencer), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutInfluencer(int id, [FromBody] InfluencerDTO influencerDTO)
        {
            //var category = _mapper.Map<InfluencerDTO, Influencer>(influencerDTO);
            var influencer = new Influencer
            {
                NameOfInfluencer = influencerDTO.NameOfInfluencer,
                EmailAddress = influencerDTO.EmailAddress,
                Role = influencerDTO.Role,
                CampaignId = influencerDTO.CampaignId,
                InstagramHandle = influencerDTO.InstagramHandle,
                TwitterHandle = influencerDTO.TwitterHandle,
                FacebookHanlde = influencerDTO.FacebookHanlde,
                LinkedKeywords = influencerDTO.LinkedKeywords
            };
            var result = await _influencerService.UpdateAsync(id, influencer);


            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var influencerResource = result.Resource;
            return Ok(influencerResource);
        }

        /// <summary>
        /// Deletes a given influencer according to an identifier.
        /// </summary>
        /// <param name="id">Influencer identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Influencer), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteInfluencer(int id)
        {
            var result = await _influencerService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var influenceResource = result.Resource;
            return Ok(influenceResource);
        }


        /// <summary>
        /// Get Influencer details according to an identifier.
        /// </summary>
        /// <returns>Get Influencer details </returns>
        // GET: api/Campaigns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaign(int id)
        {
            var result = await _influencerService.FindByIdAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var influencerResource = result.Resource;
            return Ok(influencerResource);
        }




    }
}
