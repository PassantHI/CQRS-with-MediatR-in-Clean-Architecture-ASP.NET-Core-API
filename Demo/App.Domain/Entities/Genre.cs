using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }=string.Empty;
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}
