using SportEventAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SportEventAPI.Features.SportEvents.Query.Model
{
    public class SportEventResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("eventDate")]
        public string EventDate { get; set; }

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("organizer")]
        public OrganizerResponse Organizer { get; set; }
    }

    public class Links
    {
        [JsonProperty("next")]
        public string Next { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }

    public class Meta
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }

    public class ListSportEventReponse
    {
        [JsonProperty("data")]
        public List<SportEventResponse> Data { get; set; }
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public class CreateSportEventRequest
    {
        [JsonProperty("eventDate")]
        public string EventDate { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("organizerId")]
        public int OrganizerId { get; set; }
    }

    public class CreateSportEventResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("eventDate")]
        public string EventDate { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("organizerId")]
        public int OrganizerId { get; set; }
    }

}
