using App.Application.Contracts.IRepository;
using App.Application.Features.Movies.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Movies.Handlers.Commands
{
    public class DeleteMovieHandler(IUnitOfWork UOW) : IRequestHandler<DeleteMovieCommand, bool>
    {
        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await UOW.Movies.GetByIdAsync(request.Id);
            if (movie == null) return false;
            await UOW.Movies.DeleteAsync(request.Id);
            await UOW.Complete();
            return true;
        }
    }
}
