using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;
        public PostController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]

        [HttpPost]
        public IActionResult CreatePost([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest("Post object is null");
            }

            var userName = User.Identity.Name; // Assuming you store the user id in the claims.

            var user = _context.Users.Where(e => e.Username == userName).FirstOrDefault();

            post.UserId = user.Id;

            _context.Posts.Add(post);
            _context.SaveChanges();

            return Ok(new { postId = post.Id });
        }
        [HttpGet]
        public IActionResult GetPost()
        {
            var usersWithPosts = _context.Users
                   .Include(user => user.Posts) // Assuming you have a navigation property called Posts in your User model
                   .ToList();

            return Ok(usersWithPosts);
        }


    }
}
