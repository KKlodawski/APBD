using System;

namespace MovieApp.Shared.DTOs
{
    public class MovieAddDto
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public bool InTheaters { get; set; }
        public string Trailer { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Poster { get; set; }
        public int? GenreId { get; set; }
        public int? PersonId { get; set; }
        public string? Character { get; set; }
        public int? Order { get; set; }
    }
}