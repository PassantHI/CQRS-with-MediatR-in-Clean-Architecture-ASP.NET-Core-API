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
    public class AddMovieHandler(IUnitOfWork UOW) : IRequestHandler<AddMovieCommand, MovieDTO>
    {
        public async Task<MovieDTO> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = request.MovieDTO.Adapt<Movie>();
            var added =await UOW.Movies.AddAsync(movie);
            await UOW.Complete();
            return added.Adapt<MovieDTO>();

        }
    }
}
