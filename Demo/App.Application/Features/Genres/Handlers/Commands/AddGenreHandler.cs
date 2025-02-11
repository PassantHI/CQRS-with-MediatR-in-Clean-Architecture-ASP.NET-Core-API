using App.Application.Contracts.IRepository;
using App.Application.DTOs;
using App.Application.Features.Genres.Commands;
using App.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Genres.Handlers.Commands
{
    public class AddGenreHandler (IUnitOfWork UOW): IRequestHandler<AddGenreCommand, GenreDTO>
    {
        public async Task<GenreDTO> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = request.genreDTO.Adapt<Genre>();
            var added = await UOW.Genres.AddAsync(genre);
            await UOW.Complete();
            return added.Adapt<GenreDTO>();
        }
    }
}
