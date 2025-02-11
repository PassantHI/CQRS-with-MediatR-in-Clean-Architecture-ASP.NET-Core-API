using App.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Commands
{
    public class UpdateMovieCommand:IRequest<MovieDTO>
    {

        public MovieDTO MovieDTO { get; }

        public UpdateMovieCommand(MovieDTO movieDTO)
        {
            MovieDTO = movieDTO;
        }
    }
}
