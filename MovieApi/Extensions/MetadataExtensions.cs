using MovieApi.Models;

namespace MovieApi.Extensions
{
    public static class MetadataExtensions
    {
        public static bool IsValid(this Metadata m)
        {
            return m.Title.HasValue() && 
                   m.Language.HasValue() && 
                   m.Duration.HasValue();
        }

        private static bool HasValue(this string value) => !string.IsNullOrEmpty(value);
    }
}