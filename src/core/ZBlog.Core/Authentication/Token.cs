using System;
using Newtonsoft.Json;

namespace ZBlog.Core.Authentication
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("expires_in")]
        public DateTime ExpireDate { get; set; }
        [JsonProperty("token_type")]
        public string Type { get; set; }
    }
}
