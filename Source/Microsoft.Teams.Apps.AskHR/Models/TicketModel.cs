namespace Microsoft.Teams.Apps.AskHR.Models
{
    /// <summary>
    /// model to receive ticket's data
    /// </summary>
    public class TicketModel
    {
        /// <summary>
        /// Case number
        /// </summary>
        public string CaseNumber { get; set; }

        /// <summary>
        /// Ticket title
        /// </summary>
        public string TicketTitle { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        public string CustomerName { get; set; }

        public string TicketStatus { get; set; }
        public string CreatedDate { get; set; }
    }
}