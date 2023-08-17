using Microsoft.AspNetCore.Mvc;
using My_Thyme.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My_Thyme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipePostController : ControllerBase
    {
        private APIFormatter formatter;

        public RecipePostController(MythymeContext context)
        {
            formatter = new APIFormatter(context);
        }


        // POST api/<RecipePostController>
        [HttpPost("{recipe}/{post}")]
        public IActionResult Post(long recipe, long post)
        {
            (bool success, string error) RP = formatter.CreateRPAssociation(recipe, post);
            string errorMessage = string.Empty;
            if (RP.success)
            {
                return Ok($"Association between recipe {recipe} and post {post} created successfully.");
            }
            else
            {
                return BadRequest(RP.error);
            }

        }

        // DELETE api/<RecipePostController>/5
        [HttpDelete("{recipe}/{post}")]
        public IActionResult Delete(long recipe, long post)
        {
            (bool success, string error) RP = formatter.DeleteRPAssociation(recipe, post);
            if (RP.success)
            {
                return Ok($"Association between recipe {recipe} and post {post} successfully deleted.");
            }
            else
            {
                return BadRequest(RP.error);
            }
        }
    }
}
