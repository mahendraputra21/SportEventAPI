﻿using Newtonsoft.Json;

namespace SportEventAPI.Domain
{
    public class Users
    {
        [JsonProperty("id")]
        public int Id { get; set; }
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
