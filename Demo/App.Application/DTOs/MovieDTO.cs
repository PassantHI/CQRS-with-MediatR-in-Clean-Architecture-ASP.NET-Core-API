namespace App.Application.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public required int GenreId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Language { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
        
        public decimal Rate { get; set; }
        public string Director { get; set; } = string.Empty;
        public string ProductionCompany { get; set; } = string.Empty;
        
    }
}
