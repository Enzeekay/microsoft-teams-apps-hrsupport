using System.Threading.Tasks;
using Microsoft.Teams.Apps.AskHR.ApiModel;

namespace Microsoft.Teams.Apps.AskHR.Services
{
    public interface IUserService
    {
        Task<UserInfoModel> GetUserDetail(string email);
    }
}