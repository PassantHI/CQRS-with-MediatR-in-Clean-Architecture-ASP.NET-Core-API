﻿using App.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Genres.Queries
{
    public class GetGenreQuery:IRequest<GenreDTO>
    {
        public int Id { get; }

        public GetGenreQuery(int id)
        {
            Id = id;
        }
    }
}
