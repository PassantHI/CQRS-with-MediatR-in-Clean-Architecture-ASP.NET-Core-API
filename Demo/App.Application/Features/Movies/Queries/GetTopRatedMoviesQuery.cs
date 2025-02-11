using App.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Queries
{
    public class GetTopRatedMoviesQuery:IRequest<IEnumerable<MovieDTO>>
    {
        public int NTop { get; set; }

        public GetTopRatedMoviesQuery(int nTop)
        {
            NTop = nTop;
        }
    }
}
