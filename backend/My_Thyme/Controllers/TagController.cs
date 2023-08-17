using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using My_Thyme.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My_Thyme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private APIFormatter formatter;

        public TagController(MythymeContext context) { 
            formatter = new APIFormatter(context);
        }

        // GET: api/<TagController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(formatter.GetTags());
        }

        // GET api/<TagController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var tag = formatter.GetTag(id);
            if (!string.IsNullOrEmpty(tag.error))
            {
                return NotFound(tag.error);
            }
            else
            {
                return Ok(tag.tag);
            }

            

        }

        // DELETE api/<TagController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var tag = formatter.DeleteTag(id);
            if (!string.IsNullOrEmpty(tag.error))
            {
                return NotFound(tag.error);
            }

            return Ok($"Tag with id-{id} deleted successfully");
        }
    }
}
