using Newtonsoft.Json;

namespace Microsoft.Teams.Apps.AskHR.ApiModel
{
    public class GetUserRequestModel
    {
        [JsonProperty("mail")]
        public string Mail { get; set; }
    }
}