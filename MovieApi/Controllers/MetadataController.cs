using System;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        private readonly IMetadataService _service;

        public MetadataController(IMetadataService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route(":{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var metadata = _service.Get(id);
                return Ok(metadata);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(Metadata model)
        {
            var result = _service.Post(model);
            return Ok();
        }
    }
}