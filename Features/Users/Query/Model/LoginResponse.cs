using Newtonsoft.Json;

namespace SportEventAPI.Models
{
    public class LoginResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }

    }
}
