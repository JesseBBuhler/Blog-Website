using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using My_Thyme.APIObjects;
using My_Thyme.Models;
using System.Linq;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My_Thyme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private APIFormatter formatter;

        public PostsController(MythymeContext context)
        {
            formatter = new APIFormatter(context);
        }

        // GET: api/Posts
        [HttpGet]
        public IActionResult Get()
        {
            var posts = formatter.GetPosts();
            
            return Ok(posts);
        }

        // GET api/Posts/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = formatter.GetPost(id);
            if (!string.IsNullOrEmpty(post.Error))
            {
                return NotFound(new { ErrorCode = 404, ErrorMessage = post.Error });
            }

            return Ok(post.Content);

        }

        // POST api/Posts
        [HttpPost]
        public IActionResult Post([FromBody] postPost model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var createdPost = formatter.PostPost(model);

            if (!string.IsNullOrEmpty(createdPost.Error))
            {
                return NotFound(new { ErrorCode = 404, ErrorMessage = createdPost.Error });
            }

            return CreatedAtAction(nameof(Get), new { id = createdPost.Content.PostId }, createdPost.Content);
        }

        // PUT api/Posts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] postPost model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editedPost = formatter.EditPost(model);

            if (!string.IsNullOrEmpty(editedPost.Error))
            {
                return NotFound(new { ErrorCode = 404, ErrorMessage = editedPost.Error });
            }

            return CreatedAtAction(nameof(Get), new { id = editedPost.Content.PostId }, editedPost.Content);

        }

        // DELETE api/Posts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
