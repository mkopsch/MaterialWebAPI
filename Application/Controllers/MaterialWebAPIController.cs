using System.Collections.Generic;
using AutoMapper;
using MaterialWebAPI.Application.Models;
using MaterialWebAPI.Domain.Entities;
using MaterialWebAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MaterialWebAPI.Application.Controllers
{
    [Route("/materials/")]
    [ApiController]
    public class MaterialWebAPIController : ControllerBase
    {
        private readonly IRepository<Material> _repository;
        private readonly ILogger<MaterialWebAPIController> _logger;
        private readonly IMapper _mapper;
        
        public MaterialWebAPIController(IRepository<Material> repository, ILogger<MaterialWebAPIController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(":id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(string id)
        {
            var material = _repository.Select(id);

            if (material == null)
            {
                return NotFound("The reference material with id :" + id + " " + "was not Found in the Database!");
            }


            var materialResult = new MaterialModel()
            {
                Id = material.Id,
                Name = material.Name,
                IsVisible = material.IsVisible,
                TypeOfPhase = material.TypeOfPhase,
                MaterialFunction = material.MaterialFunction
            };

            return Ok(materialResult);
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            List<MaterialModel> materialsModel = new();

            var materials = _repository.SelectAll();

            foreach (var material in materials)
            {
                var materialResult = new MaterialModel()
            {
                Id = material.Id,
                Name = material.Name,
                IsVisible = material.IsVisible,
                TypeOfPhase = material.TypeOfPhase,
                MaterialFunction = material.MaterialFunction
            };

                materialsModel.Add(materialResult);
            }

            return Ok(materialsModel);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create(MaterialModel materialModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Sorry, the data model is invalid :(");

            var material = _mapper.Map<Material>(materialModel);
            
            try
            {
                _repository.Create(material);
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return StatusCode(500);
            }

            if (string.IsNullOrWhiteSpace(materialModel.Id))
                return CreatedAtAction(nameof(Get), new { material.Id });

            return Ok(material);
        }

        [HttpPut(":id")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(string id, MaterialModel materialModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Sorry, the data model is invalid :(");

            var material = _mapper.Map<Material>(materialModel);

            material.Id = id;
            
            try
            {
                _repository.Update(material.Id, material);
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return StatusCode(500);
            }

            return Ok(material);
        }



        [HttpDelete(":id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Sorry, the data model is invalid :(");
            try
            {
                _repository.Delete(id);
            }
            catch (RepositoryException ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                return StatusCode(500);
            }

            return Ok(id);
        }
    }
}
