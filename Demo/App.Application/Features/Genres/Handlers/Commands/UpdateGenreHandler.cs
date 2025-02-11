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
    public class UpdateGenreHandler(IUnitOfWork UOW) : IRequestHandler<UpdateGenreCommand, GenreDTO>
    {
        public async Task<GenreDTO> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = request.genreDTO.Adapt<Genre>();
            var edit = await UOW.Genres.UpdateAsync(genre);
            await UOW.Complete();
            return edit.Adapt<GenreDTO>();
        }
    }
}
