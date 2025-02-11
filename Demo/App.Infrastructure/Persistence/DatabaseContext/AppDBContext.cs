using App.Domain.Entities;
using App.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Persistence.DatabaseContext
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Watchlist> Watchlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\sqlexpress;Database=MovieAppAPI;Integrated Security=sspi;TrustServerCertificate=true;Encrypt=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Review>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .IsRequired();


            builder.Entity<Watchlist>()
                .HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Watchlist>(k => k.UserId);



            base.OnModelCreating(builder);
        }
    }
}
