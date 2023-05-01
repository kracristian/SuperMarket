using Microsoft.EntityFrameworkCore;
using SuperMarket.Data.Model;

namespace SuperMarcket.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Parqueadero> Parqueaderos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Permisos>().ToTable("Permiso");
            modelBuilder.Entity<Parqueadero>().ToTable("Parqueadero");
        }

    }
}