using Microsoft.AspNetCore.Mvc;
using MovieApi.Interfaces;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("stats")]
        public IActionResult Get()
        {
            var stats = _service.Get();
            return Ok(stats);
        }
    }
}