using App.Application.Contracts.IRepository;
using App.Application.DTOs;
using App.Application.Features.Movies.Commands;
using App.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Handlers.Commands
{
    class UpdateMovieHandler(IUnitOfWork UOW) : IRequestHandler<UpdateMovieCommand, MovieDTO>
    {
        public async Task<MovieDTO> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = request.MovieDTO.Adapt<Movie>();
            var edit=await UOW.Movies.UpdateAsync(movie);
            await UOW.Complete();
            return edit.Adapt<MovieDTO>();
        }
    }
}
