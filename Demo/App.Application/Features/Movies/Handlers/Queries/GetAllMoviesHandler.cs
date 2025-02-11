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
    public class GetAllMoviesHandler(IUnitOfWork UOW) : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieDTO>>
    {
        public async Task<IEnumerable<MovieDTO>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {

            var movies = await UOW.Movies.GetAllAsync();
            return movies.Adapt<IEnumerable<MovieDTO>>();
        }
    }
}
