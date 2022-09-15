using Newtonsoft.Json;

namespace SportEventAPI.Models
{
    public class OrganizerModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
