using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using My_Thyme.Models;
using My_Thyme.returnObjects;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My_Thyme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private APIFormatter formatter;

        public RecipesController(MythymeContext context)
        {
            formatter = new APIFormatter(context);
        }
        // GET: api/Recipes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(formatter.GetRecipes());
        }

        // GET api/Recipes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var recipe = formatter.GetRecipe(id);
            if (!string.IsNullOrEmpty(recipe.Error))
            {
                return NotFound(new { ErrorCode = 404, ErrorMessage = recipe.Error });
            }

            return Ok(recipe.Content);
        }

        // POST api/Recipes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Recipes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Recipes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
