using App.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Queries
{
    public class GetMovieQuery : IRequest<MovieDTO>
    {
        public int Id { get; }

        public GetMovieQuery(int id)
        {
            Id = id;
        }
    }
}
