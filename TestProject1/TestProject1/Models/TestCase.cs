using System.Text.Json.Serialization;

namespace TestProject1.Models
{
    public class TestCase
    {
        [JsonPropertyName("url")] 
        public string Url { get; set; }
        [JsonPropertyName("postsPath")] 
        public string PostsPath { get; set; }
        [JsonPropertyName("usersPath")] 
        public string UsersPath { get; set; }
    }
}