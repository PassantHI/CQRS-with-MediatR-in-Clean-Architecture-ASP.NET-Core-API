using App.Application.Contracts.IRepository;
using App.Domain.Entities;
using App.Infrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork :IUnitOfWork
    {

        private readonly AppDBContext _context;
        public IBaseRepository<Movie> Movies  { get; private set; }
        public IBaseRepository<Genre> Genres { get; private set; }
        public IBaseRepository<Review> Reviews { get; private set; }
        public IBaseRepository<Watchlist> Watchlists { get; private set; }


        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            Movies = new BaseReporitory<Movie>(_context);
            Genres = new BaseReporitory<Genre>(_context);
            Reviews = new BaseReporitory<Review>(_context);
            Watchlists = new BaseReporitory<Watchlist>(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
