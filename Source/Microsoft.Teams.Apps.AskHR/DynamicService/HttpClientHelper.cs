using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Microsoft.Teams.Apps.AskHR.DynamicService
{
    public static class HttpClientHelper<T, TR> where T : class
    {

        public static async Task<T> PostAsync(string url, TR postObject)
        {
            T result = null;
            using (var client = new HttpClient())
            {
                var postResult = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(postObject), Encoding.UTF8, "application/json")).ConfigureAwait(false);
                postResult.EnsureSuccessStatusCode();
                var content = await postResult.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(content);
            }

            return result;
        }
    }
}