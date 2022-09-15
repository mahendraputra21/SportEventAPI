using Newtonsoft.Json;

namespace SportEventAPI.Models
{
    public class OrganizerResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("organizerName")]
        public string OrganizerName { get; set; }
        [JsonProperty("imageLocation")]
        public string ImageLocation { get; set; }
    }
}
