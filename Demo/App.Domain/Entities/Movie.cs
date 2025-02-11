using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public required int GenreId {  get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Language {  get; set; }= string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public string TrailerUrl { get; set; }= string.Empty;
        public decimal Rate {  get; set; }
        public string Director  { get; set;} = string.Empty;
        public string ProductionCompany { get; set; }=string.Empty;

        [ForeignKey(nameof(GenreId))]
        public virtual required Genre Genre { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();

    }
}
