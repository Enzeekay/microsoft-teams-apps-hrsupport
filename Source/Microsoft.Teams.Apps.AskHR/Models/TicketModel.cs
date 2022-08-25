using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "ticketNumber")]
        public string CaseNumber { get; set; }

        /// <summary>
        /// Ticket title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string TicketTitle { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string TicketStatus { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public string CreatedDate { get; set; }
    }
}