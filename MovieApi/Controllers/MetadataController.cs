using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        [Route(":{id:int}")]
        public IActionResult Get(int id)
        {
            if (id > 5) return StatusCode(404);
            return new JsonResult(new Metadata
            {
                MovieId = id,
                Title = "Baby Driver",
                Language = "EN",
                Duration = "1:39:00",
                ReleaseYear = 2018
            });
        }

        [HttpPost]
        public IActionResult Post(Metadata model)
        {
            return StatusCode(200);
        }
    }
}