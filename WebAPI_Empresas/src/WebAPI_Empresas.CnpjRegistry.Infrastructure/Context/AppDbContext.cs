using Microsoft.EntityFrameworkCore;
using CnpjRegistry.Domain.Entities;

namespace CnpjRegistry.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
