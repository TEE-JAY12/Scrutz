using Scrutz.Model;
using Scrutz.Service.Communication;

namespace Scrutz.Service.Interface
{
    public interface IAccountSettingService
    {
        
        Task<AccountSettingResponse> AddAsync(AccountSetting accountSetting);
        Task<AccountSettingResponse> FindByIdAsync(int id);
        Task<AccountSettingResponse> UpdateAsync(int id, AccountSetting accountSetting);

    }
}
