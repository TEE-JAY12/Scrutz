﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using Scrutz.Model;
using Scrutz.Model.DTO;
using Scrutz.Resource;
using Scrutz.Service.Interface;

namespace Scrutz.Controllers
{
    [Authorize]
    [RequiredScope("Access_as_user")]
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        private readonly IMapper _mapper;

        public CampaignController(ICampaignService campaignService, IMapper mapper)
        {
            _campaignService = campaignService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all campaigns.
        /// </summary>
        /// <returns>List os campaigns.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Campaign>), 200)]
        public async Task<IEnumerable<Campaign>> GetCampaigns()
        {
            var campaigns = await _campaignService.ListAsync();
            

            return campaigns;
        }

        /// <summary>
        /// Saves a new campaign.
        /// </summary>
        /// <param name="campaign">Category data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Campaign), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostCampaign([FromBody] CampaignDTO campaignDTO)
        {
            var category = _mapper.Map<CampaignDTO, Campaign>(campaignDTO);
            var result = await _campaignService.AddAsync(category);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var campaignResource = result.Resource;
            return Ok(campaignResource);
        }

        /// <summary>
        /// Updates an existing category according to an identifier.
        /// </summary>
        /// <param name="id">Category identifier.</param>
        /// <param name="campaign">Updated category data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Campaign), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutCampaign(int id, [FromBody] CampaignDTO campaignDTO)
        {
            var category = _mapper.Map<CampaignDTO, Campaign>(campaignDTO);
            var result = await _campaignService.UpdateAsync(id, category);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var campaignResource = result.Resource;
            return Ok(campaignResource);
        }

        /// <summary>
        /// Deletes a given category according to an identifier.
        /// </summary>
        /// <param name="id">Category identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Campaign), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteCampaign(int id)
        {
            var result = await _campaignService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var campaignResource = result.Resource;
            return Ok(campaignResource);
        }

        // GET: api/Campaigns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaign(int id)
        {
            var result = await _campaignService.FindByIdAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var campaignResource = result.Resource;
            return Ok(campaignResource);
        }

        [HttpPut("UpdateActiveStatus/{id}")]
        [ProducesResponseType(typeof(Campaign), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateActiveStatus(int id, [FromQuery] ActiveStatus activeStatus)
        {
            //var category = _mapper.Map<CampaignDTO, Campaign>(campaignDTO);
            var result = await _campaignService.UpdateActiveStatus(id, activeStatus);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var campaignResource = result.Resource;
            return Ok(campaignResource);
        }


    }
}
