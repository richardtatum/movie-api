using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IMovieService
    {
        Stats[] Get();
    }
}