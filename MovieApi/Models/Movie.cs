﻿namespace MovieApi.Models
{
    public abstract class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
    }
}