using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface ICommandRepository
    {
        bool Insert(Metadata metadata);
    }
}