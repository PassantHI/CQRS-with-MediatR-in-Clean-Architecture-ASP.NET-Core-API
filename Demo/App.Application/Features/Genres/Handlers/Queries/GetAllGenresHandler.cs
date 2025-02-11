using App.Application.Contracts.IRepository;
using App.Application.DTOs;
using App.Application.Features.Genres.Queries;
using App.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Genres.Handlers.Queries
{
    public class GetAllGenresHandler(IUnitOfWork UOW) : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreDTO>>
    {
        public async Task<IEnumerable<GenreDTO>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var gernes = await UOW.Genres.GetAllAsync();
            return  gernes.Adapt<IEnumerable<GenreDTO>>();
        }
    }
}
