using App.Application.Contracts.IRepository;
using App.Application.DTOs;
using App.Application.Features.Genres.Queries;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Genres.Handlers.Queries
{
    public class GetGenreHandler(IUnitOfWork UOW) : IRequestHandler<GetGenreQuery, GenreDTO>
    {
        public async Task<GenreDTO> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await UOW.Genres.GetByIdAsync(request.Id);
            return genre.Adapt<GenreDTO>();

        }
    }
}
