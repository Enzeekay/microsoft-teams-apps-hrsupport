using System.Threading.Tasks;
using Microsoft.Teams.Apps.AskHR.ApiModel;
using Microsoft.Teams.Apps.AskHR.DynamicService;

namespace Microsoft.Teams.Apps.AskHR.Services
{
    public class UserService : IUserService
    {
        /// <summary>
        /// constructor
        /// </summary>
        public UserService()
        {
        }

        public async Task<UserInfoModel> GetUserDetail(string email)
        {
            const string baseUrl = "https://prod-04.japaneast.logic.azure.com:443/workflows/585e9daa1fe34d93b10eb717f02e79a3/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=RTRQr23703C7cROisiHD6wHFyuijiiOAuFScsq5AoJo";
            var getUserInfo = await HttpClientHelper<UserInfoModel, GetUserRequestModel>.PostAsync(baseUrl, new GetUserRequestModel { Mail = email });
            return getUserInfo;
        }
    }
}