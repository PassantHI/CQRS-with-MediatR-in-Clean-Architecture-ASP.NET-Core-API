using App.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Genres.Commands
{
    public class AddGenreCommand:IRequest<GenreDTO>
    {
        public GenreDTO genreDTO { get;  }

        public AddGenreCommand(GenreDTO genreDTO)
        {
            this.genreDTO = genreDTO;
        }
    }
}
