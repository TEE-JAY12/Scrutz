using Scrutz.Model;
using Scrutz.Service.Communication;

namespace Scrutz.Service.Interface
{
    public interface IAccountSettingService
    {
        
        Task<AccountSetting> AddAsync(AccountSetting accountSetting);
        Task<AccountSetting> FindByIdAsync(int id);
        Task<AccountSetting> UpdateAsync(int id, AccountSetting accountSetting);

    }
}
