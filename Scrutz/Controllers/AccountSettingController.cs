using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Scrutz.Model.DTO;
using Scrutz.Model;
using Scrutz.Resource;
using Scrutz.Service;
using Scrutz.Service.Interface;

namespace Scrutz.Controllers
{
    [Authorize]
    [RequiredScope("Access_as_user")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountSettingController : ControllerBase
    {
        private readonly IAccountSettingService _accountSettingService;
        private readonly IMapper _mapper;

        public AccountSettingController(IAccountSettingService accountSettingService, IMapper mapper)
        {
            _accountSettingService = accountSettingService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get account settings according to an identifier.
        /// </summary>
        /// <returns>Get Account Settings details </returns>
        // GET: api/Campaigns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountSettings(int id)
        {
            var result = await _accountSettingService.FindByIdAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var SavedAccountSettings = result.Resource;
            return Ok(SavedAccountSettings);
        }


        /// <summary>
        /// Saves a new Account Settings.
        /// </summary>
        /// <param name="AccountSettings">AccountSetting  data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(AccountSetting), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAccounSettings([FromBody] AccountSettingDTO accountSettingDTO)
        {
            var AccountSettings = _mapper.Map<AccountSettingDTO, AccountSetting>(accountSettingDTO);
            var result = await _accountSettingService.AddAsync(AccountSettings);

          

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var SavedAccountSettings = result.Resource;
            return Ok(SavedAccountSettings);
        }

        /// <summary>
        /// Updates an existing account settings according to an identifier.
        /// </summary>
        /// <param name="id">Campaign identifier.</param>
        /// <param name="AccountSettings">Updated campaign data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AccountSetting), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> EditAccountSettings(int id, [FromBody] AccountSettingDTO accountSettingDTO)
        {
            var AccountSettings = _mapper.Map<AccountSettingDTO, AccountSetting>(accountSettingDTO);
            var result = await _accountSettingService.UpdateAsync(id, AccountSettings);


            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var SavedAccountSettings = result.Resource;
            return Ok(SavedAccountSettings);
        }

        /// <summary>
        /// Upload an Image.
        /// </summary>
        /// <param name="id">Campaign identifier.</param>
        /// <param name="AccountSettings">Updated campaign data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("UploadCompanyLogo/{id}")]
        [ProducesResponseType(typeof(AccountSetting), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {
            
            var result = await _accountSettingService.UploadImage(id, file);


            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var SavedAccountSettings = result.Resource;
            return Ok(SavedAccountSettings);
        }

        /// <summary>
        /// Get company Logo according to an identifier.
        /// </summary>
        /// <returns>Get company logo </returns>
        // GET: api/Campaigns/5
        [HttpGet("RetrieveImage/{id}")]
        public async Task<IActionResult> GetCompanyLogo(int id)
        {
            var base64Data = await _accountSettingService.RetrieveImage(id);
            if (base64Data == null)
            {
                return NotFound();
            }

            var bytes = Convert.FromBase64String(base64Data);
            return File(bytes, "image/png");
        }





    }
}
