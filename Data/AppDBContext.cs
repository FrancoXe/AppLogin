using Microsoft.EntityFrameworkCore;
using AppLogin.Models;

namespace AppLogin.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Rol> Roles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>(tb =>
            {
                tb.HasKey(col => col.IdRol);
                tb.Property(col => col.NombreRol).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Rol>().HasData(
                new Rol { IdRol = 1, NombreRol = "Vecino" },
                new Rol { IdRol = 2, NombreRol = "Administrador" },
                new Rol { IdRol = 3, NombreRol = "Departamento" }
            );

            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.HasKey(col => col.IdUsuario);
                tb.Property(col => col.IdUsuario).UseIdentityColumn().ValueGeneratedOnAdd();

                tb.Property(col => col.NombreCompleto).HasMaxLength(50).IsRequired();
                tb.Property(col => col.Correo).HasMaxLength(50).IsRequired();
                tb.Property(col => col.Clave).HasMaxLength(50).IsRequired();
                tb.Property(col => col.IdRol).HasDefaultValue(1); // Rol predeterminado "Vecino"

                tb.HasOne(col => col.Rol)
                  .WithMany()
                  .HasForeignKey(col => col.IdRol);
            });

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}

