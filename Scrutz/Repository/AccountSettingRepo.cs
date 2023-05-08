using Scrutz.Data;
using Scrutz.Model;
using Scrutz.Repository.Interface;

namespace Scrutz.Repository
{
    public class AccountSettingRepo : BaseRepo, IAccountSettingRepo
    {
        public AccountSettingRepo(ScrutzContext context) : base(context)
        {
        }

        public async Task AddSettingsAsync(AccountSetting accountSetting)
        {
            await _context.AccountSettings.AddAsync(accountSetting);
        }

        public async Task<AccountSetting> FindSettingsAsync(int id)
        {
            return await _context.AccountSettings.FindAsync(id);
        }

        public void Update(AccountSetting accountSetting)
        {
            _context.AccountSettings.Update(accountSetting);
        }
    }
}
