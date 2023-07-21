using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Thyme.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My_Thyme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private MythymeContext _context;

        public PostsController(MythymeContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "post1", "post2" };
        }

        // GET api/Posts/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var postString = "";
            var post = _context.Posts.Where(x => x.PostId == id).FirstOrDefault();
            var recipes = _context.Recipes
            .Where(recipe => _context.Posts
            .Where(post => post.PostId == id)
            .Any(post => post.Recipes.Any(postRecipe => postRecipe.RecipeId == recipe.RecipeId)))
            .ToList();

            if (post == null) { postString += "404: Post not found."; } else
            {
                postString = $"Title: {post.PostTitle}";
                postString += $"\nContent: {post.PostText}";

                for (int i = 0; i < recipes.Count; i++)
                {
                    postString += $"Recipe {i}: {recipes[i].Title}\nIngredients: {recipes[i].Ingredients}\nInstructions {recipes[i].Instructions}\n";
                }
            }
            
            return postString;
        }

        // POST api/<PostsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
