using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        
        [HttpGet]
        public Stats[] Get()
        {
            return Enumerable.Range(1, 15).Select(x => new Stats
            {
                MovieId = x,
                AverageWatchDurationS = x * 1000,
                ReleaseYear = 1999,
                Title = "Best Movie",
                Watches = x * 3
            }).ToArray();
        }
    }
}