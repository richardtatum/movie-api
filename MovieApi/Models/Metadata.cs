using System.Text.Json.Serialization;

namespace MovieApi.Models
{
    public class Metadata : Movie
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
    }
}