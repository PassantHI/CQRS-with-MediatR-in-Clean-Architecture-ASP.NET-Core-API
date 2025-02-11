using App.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Genres.Queries
{
    public class GetAllGenresQuery:IRequest<IEnumerable<GenreDTO>>
    {
    }
}
