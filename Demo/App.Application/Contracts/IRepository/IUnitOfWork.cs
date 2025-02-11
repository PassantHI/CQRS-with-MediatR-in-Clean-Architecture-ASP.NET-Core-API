using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Contracts.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<Movie> Movies { get; }
        IBaseRepository<Genre> Genres { get; }
        IBaseRepository<Review> Reviews { get; }
        IBaseRepository<Watchlist> Watchlists { get; }

        Task<int> Complete();



    }
}
