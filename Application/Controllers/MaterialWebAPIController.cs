using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialWebAPIController : ControllerBase
    {
        // GET: api/MaterialWebAPI
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MaterialWebAPI/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MaterialWebAPI
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MaterialWebAPI/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/MaterialWebAPI/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
