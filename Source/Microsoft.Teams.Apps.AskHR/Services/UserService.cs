using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Teams.Apps.AskHR.ApiModel;
using Microsoft.Teams.Apps.AskHR.DynamicService;

namespace Microsoft.Teams.Apps.AskHR.Services
{
    public class UserService : IUserService
    {
        private readonly UserInfoApiSetting _setting;
        /// <summary>
        /// constructor
        /// </summary>
        public UserService(UserInfoApiSetting setting)
        {
            _setting = setting;
        }

        public async Task<UserInfoModel> GetUserDetail(string email)
        {
            var baseUrl = $"{_setting.EndPoint}/manual/paths/invoke/upn?upn={email}";
            var header = new Dictionary<string, string> { { "Client_secret", _setting.ClientSecret } };
            var getUserInfo = await HttpClientHelper<UserInfoModel>.GetAsync(baseUrl, header);
            return getUserInfo;
        }
    }
}