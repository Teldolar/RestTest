using System.Text.Json.Serialization;

namespace TestProject1.Models
{
    public class Post
    {
        [JsonPropertyName("userId")] 
        public int UserId { get; set; }
        [JsonPropertyName("id")] 
        public int Id { get; set; }
        [JsonPropertyName("title")] 
        public string Title { get; set; }
        [JsonPropertyName("body")] 
        public string Body { get; set; }

        public bool AreEqual(Post diffPost)
        {
            return UserId==diffPost.UserId&&Id==diffPost.Id&&Title==diffPost.Title&&Body==diffPost.Body;
        }
    }
}