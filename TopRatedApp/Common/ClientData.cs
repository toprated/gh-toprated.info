using Newtonsoft.Json;

namespace TopRatedApp.Common
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ClientData
    {
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "clientSecret")]
        public string ClientSecret { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

    }
}