using Scrutz.Model;
using Scrutz.Model.DTO;
using Scrutz.Service.Communication;

namespace Scrutz.Service.Interface
{
    public interface IAccountSettingService
    {
        
        Task<AccountSettingResponse> AddAsync(AccountSetting accountSetting);
        Task<AccountSettingResponse> FindByIdAsync(int id);
        Task<AccountSettingResponse> UpdateAsync(int id, AccountSetting accountSetting);
        //Task<AccountSettingResponse> UploadImage(int id, ImageUploadDTO imageUploadDTO);
        Task<AccountSettingResponse> UploadImage(int id, IFormFile file);

        Task<String> RetrieveImage(int id);

    }
}
