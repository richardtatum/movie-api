namespace MovieApi.Models
{
    public class Stats : Movie
    {
        public int AverageWatchDurationS { get; set; }
        public int Watches { get; set; }
    }
}