using System.Collections.Generic;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        private readonly List<Metadata> _database;
        
        public CommandRepository()
        {
            _database = new List<Metadata>();
        }
        
        public bool Insert(Metadata metadata)
        {
            _database.Add(metadata);
            return true;
        }
    }
}