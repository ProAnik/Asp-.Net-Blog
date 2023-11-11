using System.Text.Json.Serialization;

namespace Blog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        // This attribute excludes the property from Swagger documentation
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
