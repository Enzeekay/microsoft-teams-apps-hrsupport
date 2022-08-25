using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Microsoft.Teams.Apps.AskHR.DynamicService
{
    public static class HttpClientHelper<T> where T : class
    {

        public static async Task<T> PostAsync(string url, object postObject)
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

        public static async Task<T> GetAsync(string url, Dictionary<string, string> headers = null)
        {
            T result = null;
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                var res = await client.GetAsync(url);
                var content = await res.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(content);
            }

            return result;
        }
    }
}