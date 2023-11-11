using System.Text.Json.Serialization;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }

        [JsonIgnore] 
        public virtual User? User { get; set; }
    }
}
