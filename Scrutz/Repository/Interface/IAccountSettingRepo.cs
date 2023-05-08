using Scrutz.Model;

namespace Scrutz.Repository.Interface
{
    public interface IAccountSettingRepo
    {
        //Task<IEnumerable<Campaign>> ListAsync();
        Task AddSettingsAsync(AccountSetting accountSetting);
        Task<AccountSetting> FindSettingsAsync(int id);
        void Update(AccountSetting accountSetting);
        //void Remove(AccountSettingRepo accountSetting);
    }
}
