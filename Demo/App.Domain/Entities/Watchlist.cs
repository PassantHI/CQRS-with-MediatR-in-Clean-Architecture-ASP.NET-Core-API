using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Watchlist
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public DateTime AddDate { get; set; }
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
