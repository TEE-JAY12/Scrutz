using AutoMapper;
using Scrutz.Model;
using Scrutz.Model.DTO;

namespace Scrutz.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile() 
        {
            CreateMap<CampaignDTO,Campaign>();
            CreateMap<AccountSettingDTO,AccountSetting>();
        }
    }
}
