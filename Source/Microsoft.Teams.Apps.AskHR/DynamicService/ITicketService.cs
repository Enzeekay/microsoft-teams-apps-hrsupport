using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Teams.Apps.AskHR.Models;

namespace Microsoft.Teams.Apps.AskHR.DynamicService
{
    /// <summary>
    /// Ticket service
    /// </summary>
    public interface ITicketService
    {
        /// <summary>
        /// get my tickets
        /// </summary>
        /// <param name="username">user name</param>``
        /// <returns>return my tickets</returns>
        //Task<List<TicketModel>> GetMyTicketAsync(string username);
        Task<List<TicketModel>> GetMyTicketAsync(string username);
    }
}