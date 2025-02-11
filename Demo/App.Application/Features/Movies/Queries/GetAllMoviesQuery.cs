using App.Application.Contracts.IRepository;
using App.Application.DTOs;
using App.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Queries
{
    public class GetAllMoviesQuery :IRequest<IEnumerable<MovieDTO>>
    {
    }
}
