using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IMetadataService
    {
        Metadata[] Get(int movieId);
        bool Post(Metadata metadata);
    }
}