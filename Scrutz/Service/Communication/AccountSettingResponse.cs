using Scrutz.Model;

namespace Scrutz.Service.Communication
{
    public class AccountSettingResponse: BaseResponse<AccountSetting>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="accountSetting">Saved category.</param>
        /// <returns>Response.</returns>
        public AccountSettingResponse(AccountSetting accountSetting) : base(accountSetting)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AccountSettingResponse(string message) : base(message)
        { }
    }
}
