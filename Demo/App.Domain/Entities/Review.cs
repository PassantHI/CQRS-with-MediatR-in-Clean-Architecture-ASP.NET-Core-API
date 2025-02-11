using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public required string UserId {  get; set; }
        public required int MovieId { get; set; }
        public string Comment { get; set; }=string.Empty;
        public int Rating {  get; set; }
        public DateTime ReviewDate { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie? Movie { get; set; }

    }
}
