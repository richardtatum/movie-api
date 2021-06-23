using System.Linq;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IQueryRepository
    {
        Metadata[] GetMetadata();
        ILookup<int, int> GetStatsLookup();
    }
}