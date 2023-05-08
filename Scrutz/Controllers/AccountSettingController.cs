using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Scrutz.Service.Interface;

namespace Scrutz.Controllers
{
    [Authorize]
    [RequiredScope("Access_as_user")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountSettingController : ControllerBase
    {
        //private readonly IAccountSettingService _accountService;
        //private readonly IMapper _mapper;

        //public AccountSettingController
    }
}
