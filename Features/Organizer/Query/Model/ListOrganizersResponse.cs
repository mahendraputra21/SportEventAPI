using Newtonsoft.Json;
using System.Collections.Generic;

namespace SportEventAPI.Models
{
    public class ListOrganizersResponse
    {
        [JsonProperty("data")]
        public List<OrganizerResponse> Data { get; set; }
    }
}
