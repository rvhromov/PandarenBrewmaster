using System.Reflection;
using Microsoft.EntityFrameworkCore;
using User.Infrastructure.Extensions;

namespace User.Infrastructure.Persistence
{
    internal sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<Domain.Entities.User> Users { get; set; }
        public DbSet<Domain.Entities.Beer> Beers { get; set; }
        public DbSet<Domain.Entities.Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AppDbContext))!);
            modelBuilder.Seed();
        }
    }
}