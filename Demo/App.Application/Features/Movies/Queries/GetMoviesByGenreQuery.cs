using App.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Queries
{
    public class GetMoviesByGenreQuery:IRequest<IEnumerable<MovieDTO>>
    {
        public string genre { get; }

        public GetMoviesByGenreQuery(string genre)
        {
            this.genre = genre;
        }
    }
}
