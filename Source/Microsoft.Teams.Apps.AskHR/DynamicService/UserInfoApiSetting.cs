using System;

namespace Microsoft.Teams.Apps.AskHR.DynamicService
{
    public class UserInfoApiSetting
    {
        private static string _endpoint;
        private static string _clientSecret;
        public UserInfoApiSetting(string endpoint, string clientSecret)
        {
            _endpoint = endpoint;
            _clientSecret = clientSecret;
        }

        public string EndPoint
        {
            get => _endpoint; set

            {
                if (!string.IsNullOrEmpty(value))
                {
                    _endpoint = value;
                }
                else
                {
                    throw new Exception("EndPoint value cannot be null.");
                }
            }
        }

        public string ClientSecret
        {
            get => _clientSecret; set

            {
                if (!string.IsNullOrEmpty(value))
                {
                    _clientSecret = value;
                }
                else
                {
                    throw new Exception("ClientSecretvalue cannot be null.");
                }
            }
        }
    }
}