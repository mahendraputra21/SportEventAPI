using Newtonsoft.Json;

namespace SportEventAPI.Models
{
    public class OrganizerRequest
    {
        [JsonProperty("organizerName")]
        public string OrganizerName { get; set; }
        [JsonProperty("imageLocation")]
        public string ImageLocation { get; set; }
    }
}
