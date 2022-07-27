using Newtonsoft.Json;

namespace Microsoft.Teams.Apps.AskHR.Models
{
    public class KnowledgeBaseModel
    {
        [JsonProperty("location")]

        public string Location { get; set; }
        public string KbId { get; set; }
    }
}