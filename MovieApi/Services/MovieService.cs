using System.Collections.Generic;
using System.Linq;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IQueryRepository _query;
        
        public MovieService(IQueryRepository query)
        {
            _query = query;
        }

        public Stats[] Get()
        {
            var allMetadata = _query.GetMetadata();
            var movies = Filter(allMetadata);
            
            var statsLookup = _query.GetStatsLookup();
            return GetStats(movies, statsLookup)
                .OrderByDescending(x => x.Watches)
                .ThenByDescending(x => x.ReleaseYear)
                .ToArray();
        }

        private static IEnumerable<Stats> GetStats(Metadata[] movies, ILookup<int, int> statsLookup)
        {
            foreach (var movie in movies)
            {
                var (watches, averageDuration) = GetWatchStats(statsLookup, movie.MovieId);
                yield return new Stats
                {
                    MovieId = movie.MovieId,
                    Title = movie.Title,
                    AverageWatchDurationS = averageDuration,
                    Watches = watches,
                    ReleaseYear = movie.ReleaseYear,
                };
            }
        }

        private static (int watches, int averageDuration) GetWatchStats(ILookup<int, int> statsLookup, int movieId)
        {
            var averageDuration = (int) statsLookup[movieId].Average() / 1000;
            return (statsLookup[movieId].Count(), averageDuration);
        }

        // Filters metadata, grouping by movie id, then selecting the highest Id item with in the english language
        private static Metadata[] Filter(Metadata[] metadata)
        {
            return metadata
                .GroupBy(m => m.MovieId, m => m)
                .Select(g => g.OrderByDescending(o => o.Id))
                .Select(g => g.FirstOrDefault(f => f.Language == "EN"))
                .ToArray();
        }
    }
}