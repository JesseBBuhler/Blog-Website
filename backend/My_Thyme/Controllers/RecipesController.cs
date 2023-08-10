using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using My_Thyme.APIObjects;
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
        public IActionResult Post([FromBody] postRecipe model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRecipe = formatter.PostRecipe(model);

            if(!string.IsNullOrEmpty(createdRecipe.Error))
            {
                return NotFound(new { ErrorCode = 404, ErrorMessage =  createdRecipe.Error });
            }

            return CreatedAtAction(nameof(Get), new { id = createdRecipe.Content.RecipeId }, createdRecipe.Content);
        }

        // PUT api/Recipes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] postRecipe model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editedRecipe = formatter.EditRecipe(id, model);

            if(!string.IsNullOrEmpty(editedRecipe.Error))
            {
                return NotFound(new { ErrorCode = 404, ErrorMessage = editedRecipe.Error });
            }

            return CreatedAtAction(nameof(Get), new {id=editedRecipe.Content.RecipeId}, editedRecipe.Content);
        }

        // DELETE api/Recipes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = formatter.DeleteRecipe(id);

            if(!deleted)
            {
                return NotFound(new { error = $"Record with ID {id} not found." });
            }
            else
            {
                return Ok(new { message = $"Record with ID {id} deleted successfully." });
            }
        }
    }
}
