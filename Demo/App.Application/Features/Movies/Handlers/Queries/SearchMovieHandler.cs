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
    public class SearchMovieHandler(IUnitOfWork UOW) : IRequestHandler<SearchMovieQuery, IEnumerable<MovieDTO>>

    {
        public async Task<IEnumerable<MovieDTO>> Handle(SearchMovieQuery request, CancellationToken cancellationToken)
        {
            var movies = await UOW.Movies.GetByAsync(a => a.Title.Contains(request.Keyword), null);
            return movies.Adapt<IEnumerable<MovieDTO>>();
        }
    }
}
