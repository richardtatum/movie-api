using CsvHelper.Configuration.Attributes;

namespace MovieApi.Models
{
    public class WatchStats
    {
        [Name("movieId")]
        public int MovieId { get; set; }
        [Name("watchDurationMs")]
        public int WatchDurationMs { get; set; }
    }
}