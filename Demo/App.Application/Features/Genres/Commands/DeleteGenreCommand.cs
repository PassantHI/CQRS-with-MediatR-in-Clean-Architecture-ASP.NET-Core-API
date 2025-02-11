using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Genres.Commands
{
    public class DeleteGenreCommand:IRequest<bool>
    {
        public int Id { get; }

        public DeleteGenreCommand(int id)
        {
            Id = id;
        }
    }
}
