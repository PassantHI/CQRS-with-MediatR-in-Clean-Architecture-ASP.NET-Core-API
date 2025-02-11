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
    class GetTopRatedMoviesHandler(IUnitOfWork UOW) : IRequestHandler<GetTopRatedMoviesQuery, IEnumerable<MovieDTO>>
    {
        public async Task<IEnumerable<MovieDTO>> Handle(GetTopRatedMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await UOW.Movies.GetByOrderAsync(a => a.OrderByDescending(d => d.Rate), request.NTop);
            return movies.Adapt<IEnumerable<MovieDTO>>();
        }
    }
}
