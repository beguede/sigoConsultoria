using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ConsultoriasService.Domain.Entities;
using ConsultoriasService.Infrastructure.Database.Mapping;
using System.Diagnostics.CodeAnalysis;

namespace ConsultoriasService.Infrastructure.Database
{
    [ExcludeFromCodeCoverage]
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>(new EmpresaDbMap().Configure);
            modelBuilder.Entity<Consultoria>(new ConsultoriaDbMap().Configure);

            modelBuilder.Ignore<Notification>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Consultoria> Consultoria { get; set; }
    }
}
