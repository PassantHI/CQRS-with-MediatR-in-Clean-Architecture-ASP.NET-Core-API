using App.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Queries
{
    public class SearchMovieQuery:IRequest<IEnumerable<MovieDTO>>
    {
        public string Keyword { get; set; }

        public SearchMovieQuery(string keyword)
        {
            this.Keyword = keyword;
        }
    }
}
