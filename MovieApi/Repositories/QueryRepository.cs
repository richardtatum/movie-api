using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Repositories
{
    public class QueryRepository : IQueryRepository
    {
        private const string MetadataPath = "Data/metadata.csv";
        private const string StatsPath = "Data/stats.csv";

        private static CsvReader GetReader(string path)
        {
            return new CsvReader(new StreamReader(path), CultureInfo.InvariantCulture);
        }

        private static void SafeClose(CsvReader reader)
        {
            if (reader is null) return;
            reader.Dispose();
        }

        public Metadata[] GetMetadata()
        {
            using (var reader = GetReader("Data/metadata.csv"))
            {
                try
                {
                    var x = reader.GetRecords<Metadata>();
                    return x.ToArray();
                }
                finally
                {
                    SafeClose(reader);
                }
            }
        }

        public ILookup<int, int> GetStatsLookup()
        {
            using (var reader = GetReader("Data/stats.csv"))
            {
                try
                {
                    var records = reader.GetRecords<WatchStats>();
                    return records.ToLookup(s => s.MovieId, s => s.WatchDurationMs);
                }
                finally
                {
                    SafeClose(reader);
                }

            }
        }
        
        
    }
}