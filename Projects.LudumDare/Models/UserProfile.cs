﻿using System.Text.Json.Serialization;

namespace Projects.LudumDare.Models
{
    public class UserProfile
    {
        [JsonPropertyName("node_id")]
        public int NodeId { get; set; }
    }
}
