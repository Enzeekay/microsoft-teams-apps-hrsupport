using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Teams.Apps.AskHR.Models;

namespace Microsoft.Teams.Apps.AskHR.DynamicService
{
    public interface ITicketService
    {
        Task<List<TicketModel>> GetMyTicketAsync(string username);
    }
}