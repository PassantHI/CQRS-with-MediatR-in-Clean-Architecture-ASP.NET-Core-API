using App.Application.Contracts.IRepository;
using App.Application.Features.Genres.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Features.Genres.Handlers.Commands
{
    public class DeleteGenreHandler(IUnitOfWork UOW) : IRequestHandler<DeleteGenreCommand, bool>
    {
        public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await UOW.Genres.GetByIdAsync(request.Id);
            if (genre == null) return false;
            await UOW.Genres.DeleteAsync(request.Id);
            await UOW.Complete();
            return true;
        }
    }
}
