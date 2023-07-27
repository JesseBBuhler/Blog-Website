﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Thyme.Models;
using System.Linq;
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
        public string Get()
        {
            return JsonSerializer.Serialize(formatter.Posts());
        }

        // GET api/Posts/5
        [HttpGet("{id}")]
        public string Get(int id)
        {    
             return JsonSerializer.Serialize(formatter.Post(id));
        }

        // POST api/Posts
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Posts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Posts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}