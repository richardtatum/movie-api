using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MovieApi.Extensions;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Services
{
    public class MetadataService : IMetadataService
    {
        private readonly IQueryRepository _query;
        private readonly ICommandRepository _command;

        public MetadataService(IQueryRepository query, ICommandRepository command)
        {
            _query = query;
            _command = command;
        }

        public Metadata[] Get(int movieId)
        {
            var allMetadata = _query.GetMetadata();
            var movies = Filter(allMetadata, movieId);
            
            if (!movies.Any()) throw new Exception("No movies found by that Id");
            return movies;
        }

        public bool Post(Metadata metadata)
        {
            return _command.Insert(metadata);
        }

        // Filter the metadata by movieId, grouping by language, selecting the highest id and ordering by language 
        private static Metadata[] Filter(IEnumerable<Metadata> metadata, int movieId)
        {
            return metadata
                .Where(m => m.MovieId == movieId && m.IsValid())
                .GroupBy(m => m.Language, m => m)
                .Select(g => g.OrderByDescending(m => m.Id).FirstOrDefault())
                .OrderBy(m => m?.Language)
                .ToArray();
        }
    }
}