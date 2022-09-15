using Newtonsoft.Json;

namespace SportEventAPI.Models
{
    public class UserModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
