using System;
using Microsoft.EntityFrameworkCore;
using TestApii.Modells;

namespace TestApii.Database
{
    public class ApDbContext : DbContext
    {
        
            public ApDbContext(DbContextOptions<ApDbContext> options) : base(options)
            {

            }

            public DbSet<TmdbMovies> TmdbMovies { get; set; }
        public object Movies { get; internal set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<AuditLog>();
            modelBuilder.Entity<TmdbMovies>()
                .HasNoKey();
        }
    }
}
