using App.Application.Contracts.IRepository;
using App.Application.DTOs;
using App.Application.Features.Movies.Queries;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Handlers.Queries
{
    class GetMoviesByGenreHandler(IUnitOfWork UOW) : IRequestHandler<GetMoviesByGenreQuery, IEnumerable<MovieDTO>>
    {
        public async Task<IEnumerable<MovieDTO>> Handle(GetMoviesByGenreQuery request, CancellationToken cancellationToken)
        {
            var movies = await UOW.Movies.GetByAsync(a => a.Genre.Name == request.genre, "Genre");
            return movies.Adapt<IEnumerable<MovieDTO>>();
        }
    }
}
