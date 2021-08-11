using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterialWebAPI.Domain.Entities;
using MaterialWebAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MaterialWebAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialWebAPIController : ControllerBase
    {
        private readonly IRepository<Material> _repository;
        private readonly ILogger<MaterialWebAPIController> _logger;
        
        public MaterialWebAPIController(IRepository<Material> repository, ILogger<MaterialWebAPIController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

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
