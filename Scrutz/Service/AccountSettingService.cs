using Scrutz.Model;
using Scrutz.Repository.Interface;
using Scrutz.Service.Communication;

namespace Scrutz.Service
{
    public class AccountSettingService
    {
        private readonly IAccountSettingRepo _accountSettingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountSettingService(IAccountSettingRepo accountSettingRepository, IUnitOfWork unitOfWork)
        {
            _accountSettingRepository = accountSettingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountSettingResponse> AddAsync(AccountSetting accountSetting)
        {
            try
            {
                await _accountSettingRepository.AddSettingsAsync(accountSetting);
                await _unitOfWork.CompleteAsync();

                return new AccountSettingResponse(accountSetting);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new AccountSettingResponse($"An error occurred when saving the settings: {ex.Message}");
            }
        }

        public async Task<AccountSettingResponse> FindByIdAsync(int id)
        {
            var existingsettings = await _accountSettingRepository.FindSettingsAsync(id);
            if (existingsettings == null)
            {
                return new AccountSettingResponse("AccountSettings not found.");
            }

            return new AccountSettingResponse(existingsettings);

        }

        public async Task<AccountSettingResponse> UpdateAsync(int id, AccountSetting accountSetting)
        {
            var existingsettings = await _accountSettingRepository.FindSettingsAsync(id);
            if (existingsettings == null)
            {
                return new AccountSettingResponse("AccountSetting not found");
            }
            //_context.Entry(campaign).State = EntityState.Modified;
            existingsettings.WebsiteAddress = accountSetting.WebsiteAddress;
            existingsettings.BrandLogo = accountSetting.BrandLogo;
            

            try
            {
                await _unitOfWork.CompleteAsync();
                return new AccountSettingResponse(existingsettings);
            }
            catch (Exception ex)
            {
                return new AccountSettingResponse($"An error occurred when updating the AccountsettingResponse: {ex.Message}");
            }


        }


    }
}
