using Microsoft.AspNetCore.Mvc;
using MovieApi.Interfaces;
using MovieApi.Models;

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
        public Stats[] Get()
        {
            return _service.Get();
        }
    }
}