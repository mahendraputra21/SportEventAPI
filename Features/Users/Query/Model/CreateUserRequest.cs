using Newtonsoft.Json;

namespace SportEventAPI.Models
{
    public class CreateUserRequest
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("repeatPassword")]
        public string RepeatPassword { get; set; }
    }
}
