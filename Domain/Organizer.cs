﻿using Newtonsoft.Json;

namespace SportEventAPI.Domain
{
    public class Organizer
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("organizerName")]
        public string OrganizerName { get; set; }
        [JsonProperty("imageLocation")]
        public string ImageLocation { get; set; }
    }
}
