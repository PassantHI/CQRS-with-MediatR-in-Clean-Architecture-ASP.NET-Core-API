using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Commands
{
    public class DeleteMovieCommand:IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteMovieCommand(int id)
        {
            Id = id;
        }
    }
}
