using System.Text.Json.Serialization;

namespace Projects.LudumDare.Models
{
    public class UserProfileResponse
    {
        [JsonPropertyName("node_id")]
        public int NodeId { get; set; }
    }
}
