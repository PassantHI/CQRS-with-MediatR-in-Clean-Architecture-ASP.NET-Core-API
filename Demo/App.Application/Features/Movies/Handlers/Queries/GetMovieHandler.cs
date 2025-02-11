using App.Application.Contracts.IRepository;
using App.Application.DTOs;
using App.Application.Features.Movies.Queries;
using MediatR;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Handlers.Queries
{
    public class GetMovieHandler(IUnitOfWork UOW) : IRequestHandler<GetMovieQuery, MovieDTO>
    {
        public async Task<MovieDTO> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await UOW.Movies.GetByIdAsync(request.Id);
            
            return movie==null?null: movie.Adapt<MovieDTO>();

        }
    }
}
