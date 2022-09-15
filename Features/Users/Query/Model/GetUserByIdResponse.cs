using Newtonsoft.Json;

namespace SportEventAPI.Features.Users.Query.Model
{
    public class GetUserByIdResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
