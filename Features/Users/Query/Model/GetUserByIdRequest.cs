using Newtonsoft.Json;

namespace SportEventAPI.Features.Users.Query.Model
{
    public class GetUserByIdRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

    }
}
