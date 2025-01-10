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
        public DbSet<Reclamo> Reclamos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public DbSet<Barrio> Barrios { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);
                entity.Property(e => e.NombreRol).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.NombreRol).IsUnique();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);
                entity.Property(e => e.NombreCompleto).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Correo).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Clave).HasMaxLength(50).IsRequired();
                entity.Property(e => e.IdRol).HasDefaultValue(1);
                entity.Property(e => e.UltimoAcceso).IsRequired(false);

                entity.HasIndex(e => e.Correo).IsUnique();
                entity.HasIndex(e => e.IdRol);

                entity.HasOne(e => e.Rol)
                    .WithMany()
                    .HasForeignKey(e => e.IdRol)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Notificacion>(entity =>
            {
                entity.HasKey(e => e.IdNotificacion);
                entity.Property(e => e.Titulo).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Mensaje).HasMaxLength(500).IsRequired();
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.Leida).HasDefaultValue(false);

                entity.HasIndex(e => e.IdUsuario);
                entity.HasIndex(e => e.FechaCreacion);
                entity.HasIndex(e => e.Leida);

                entity.HasOne(e => e.Usuario)
                    .WithMany()
                    .HasForeignKey(e => e.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);
                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
                entity.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Subcategoria>(entity =>
            {
                entity.HasKey(e => e.IdSubcategoria);
                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();

                entity.HasIndex(e => new { e.Nombre, e.IdCategoria }).IsUnique();
                entity.HasIndex(e => e.IdCategoria);

                entity.HasOne(e => e.Categoria)
                    .WithMany(c => c.Subcategorias)
                    .HasForeignKey(e => e.IdCategoria)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.HasKey(e => e.IdBarrio);
                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
                entity.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Reclamo>(entity =>
            {
                entity.HasKey(e => e.IdReclamo);
                entity.Property(e => e.DNI).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Direccion).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(500).IsRequired();
                entity.Property(e => e.RutaArchivo).HasMaxLength(200);
                entity.Property(e => e.Estado).HasMaxLength(20).IsRequired();
                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.FechaActualizacion).IsRequired(false);

                entity.HasIndex(e => e.DNI);
                entity.HasIndex(e => e.Estado);
                entity.HasIndex(e => e.FechaCreacion);
                entity.HasIndex(e => e.IdUsuario);
                entity.HasIndex(e => e.IdCategoria);
                entity.HasIndex(e => e.IdSubcategoria);
                entity.HasIndex(e => e.IdBarrio);

                entity.HasOne(e => e.Usuario)
                    .WithMany()
                    .HasForeignKey(e => e.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Categoria)
                    .WithMany()
                    .HasForeignKey(e => e.IdCategoria)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Subcategoria)
                    .WithMany()
                    .HasForeignKey(e => e.IdSubcategoria)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Barrio)
                    .WithMany()
                    .HasForeignKey(e => e.IdBarrio)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            // Datos iniciales
            modelBuilder.Entity<Rol>().HasData(
                new Rol { IdRol = 1, NombreRol = "Vecino" },
                new Rol { IdRol = 2, NombreRol = "Administrador" },
                new Rol { IdRol = 3, NombreRol = "Departamento" }
            );

            // Datos iniciales de categorías
            var categorias = new[]
            {
                new { IdCategoria = 1, Nombre = "Alumbrado público" },
                new { IdCategoria = 2, Nombre = "Calles rutas" },
                new { IdCategoria = 3, Nombre = "Cartelería y señales" },
                new { IdCategoria = 4, Nombre = "Comercio" },
                new { IdCategoria = 5, Nombre = "Desarrollo comunitario" },
                new { IdCategoria = 6, Nombre = "Higiene urbana basura en calle" },
                new { IdCategoria = 7, Nombre = "Intendencia" },
                new { IdCategoria = 8, Nombre = "Notas varios" },
                new { IdCategoria = 9, Nombre = "Ambiente libre de humo" },
                new { IdCategoria = 10, Nombre = "Poscovid" },
                new { IdCategoria = 11, Nombre = "Reparto de agua" },
                new { IdCategoria = 12, Nombre = "Salud" },
                new { IdCategoria = 13, Nombre = "Seguridad" },
                new { IdCategoria = 14, Nombre = "Sistemas" }
            };

            modelBuilder.Entity<Categoria>().HasData(categorias);

            // Datos iniciales de subcategorías
            var subcategorias = new[]
            {
                // Alumbrado público
                new { IdSubcategoria = 1, Nombre = "Luminaria no funciona", IdCategoria = 1 },
                new { IdSubcategoria = 2, Nombre = "Poste caído", IdCategoria = 1 },
                new { IdSubcategoria = 3, Nombre = "Zona oscura", IdCategoria = 1 },
                new { IdSubcategoria = 4, Nombre = "Otros", IdCategoria = 1 },

                // Calles rutas
                new { IdSubcategoria = 5, Nombre = "Baches", IdCategoria = 2 },
                new { IdSubcategoria = 6, Nombre = "Asfalto dañado", IdCategoria = 2 },
                new { IdSubcategoria = 7, Nombre = "Arreglo de calles", IdCategoria = 2 },
                new { IdSubcategoria = 8, Nombre = "Cordon cuneta", IdCategoria = 2 },
                new { IdSubcategoria = 9, Nombre = "Limpieza de cordon cuneta", IdCategoria = 2 },
                new { IdSubcategoria = 10, Nombre = "Reductores de velocidad", IdCategoria = 2 },
                new { IdSubcategoria = 11, Nombre = "Riego de calles", IdCategoria = 2 },

                // Cartelería y señales
                new { IdSubcategoria = 12, Nombre = "Cartelería dañado", IdCategoria = 3 },
                new { IdSubcategoria = 13, Nombre = "Semáforo", IdCategoria = 3 },

                // Comercio
                new { IdSubcategoria = 14, Nombre = "Certificado de comercio", IdCategoria = 4 },

                // Desarrollo comunitario
                new { IdSubcategoria = 15, Nombre = "Modulos alimentarios", IdCategoria = 5 },

                // Higiene urbana basura en calle
                new { IdSubcategoria = 16, Nombre = "Limpieza y barrido", IdCategoria = 6 },
                new { IdSubcategoria = 17, Nombre = "Agua servida", IdCategoria = 6 },
                new { IdSubcategoria = 18, Nombre = "Escombros", IdCategoria = 6 },
                new { IdSubcategoria = 19, Nombre = "Microbasurales", IdCategoria = 6 },
                new { IdSubcategoria = 20, Nombre = "Animales muertos", IdCategoria = 6 },
                new { IdSubcategoria = 21, Nombre = "Poda y extracción", IdCategoria = 6 },
                new { IdSubcategoria = 22, Nombre = "Recolección de residuos comunes", IdCategoria = 6 },
                new { IdSubcategoria = 23, Nombre = "Recolección de residuos diferenciados", IdCategoria = 6 },
                new { IdSubcategoria = 24, Nombre = "Recolección de poda", IdCategoria = 6 },
                new { IdSubcategoria = 25, Nombre = "Desmalezados", IdCategoria = 6 },
                new { IdSubcategoria = 26, Nombre = "Estado higiénico de terreno", IdCategoria = 6 },

                // Intendencia
                new { IdSubcategoria = 27, Nombre = "Oficios", IdCategoria = 7 },
                new { IdSubcategoria = 28, Nombre = "Notas", IdCategoria = 7 },
                new { IdSubcategoria = 29, Nombre = "Ordenanzas", IdCategoria = 7 },

                // Notas varios
                new { IdSubcategoria = 30, Nombre = "Otros", IdCategoria = 8 },

                // Ambiente libre de humo
                new { IdSubcategoria = 31, Nombre = "Olor a humo en el ambiente", IdCategoria = 9 },
                new { IdSubcategoria = 32, Nombre = "Personas fumando", IdCategoria = 9 },
                new { IdSubcategoria = 33, Nombre = "Venta de cigarrillos a menores de edad", IdCategoria = 9 },
                new { IdSubcategoria = 34, Nombre = "Publicidad en lugares no correspondidos", IdCategoria = 9 },

                // Poscovid
                new { IdSubcategoria = 35, Nombre = "En análisis", IdCategoria = 10 },
                new { IdSubcategoria = 36, Nombre = "Fallecido", IdCategoria = 10 },

                // Reparto de agua
                new { IdSubcategoria = 37, Nombre = "Reparto de agua", IdCategoria = 11 },
                new { IdSubcategoria = 38, Nombre = "Reparto de agua a cabana", IdCategoria = 11 },

                // Salud
                new { IdSubcategoria = 39, Nombre = "Centro de salud forchieri", IdCategoria = 12 },
                new { IdSubcategoria = 40, Nombre = "Centro de salud san Miguel", IdCategoria = 12 },
                new { IdSubcategoria = 41, Nombre = "Centro de salud Pizarro", IdCategoria = 12 },
                new { IdSubcategoria = 42, Nombre = "Centro de salud quebrada onda", IdCategoria = 12 },
                new { IdSubcategoria = 43, Nombre = "Centro de salud cabana", IdCategoria = 12 },

                // Seguridad
                new { IdSubcategoria = 44, Nombre = "Animales sueltos", IdCategoria = 13 },
                new { IdSubcategoria = 45, Nombre = "Ruidos molestos", IdCategoria = 13 },
                new { IdSubcategoria = 46, Nombre = "Otros", IdCategoria = 13 },

                // Sistemas
                new { IdSubcategoria = 47, Nombre = "Gestión de cedulones", IdCategoria = 14 }
            };

            modelBuilder.Entity<Subcategoria>().HasData(subcategorias);

            // Datos iniciales de barrios
            var barrios = new[]
            {
                new { IdBarrio = 1, Nombre = "Todos" },
                new { IdBarrio = 2, Nombre = "Alto Alegre" },
                new { IdBarrio = 3, Nombre = "Centro" },
                new { IdBarrio = 4, Nombre = "Cigarrales A" },
                new { IdBarrio = 5, Nombre = "Cigarrales B" },
                new { IdBarrio = 6, Nombre = "Cigarrales C" },
                new { IdBarrio = 7, Nombre = "Cigarrales de Santa Rosa" },
                new { IdBarrio = 8, Nombre = "Corral de Barrancas" },
                new { IdBarrio = 9, Nombre = "Forchieri" },
                new { IdBarrio = 10, Nombre = "Gobernador Pizarro" },
                new { IdBarrio = 11, Nombre = "IPV 20 Viviendas" },
                new { IdBarrio = 12, Nombre = "IPV 34 Viviendas" },
                new { IdBarrio = 13, Nombre = "La Loma" },
                new { IdBarrio = 14, Nombre = "La Providencia" },
                new { IdBarrio = 15, Nombre = "Las Corzuelas" },
                new { IdBarrio = 16, Nombre = "Las Ensenadas" },
                new { IdBarrio = 17, Nombre = "Las Higueras" },
                new { IdBarrio = 18, Nombre = "Las Mercedes" },
                new { IdBarrio = 19, Nombre = "Lomas del Zupay" },
                new { IdBarrio = 20, Nombre = "Los Talitas" },
                new { IdBarrio = 21, Nombre = "Mutual" },
                new { IdBarrio = 22, Nombre = "Norte" },
                new { IdBarrio = 23, Nombre = "Pajas Blancas" },
                new { IdBarrio = 24, Nombre = "Parque Serrano" },
                new { IdBarrio = 25, Nombre = "Progreso" },
                new { IdBarrio = 26, Nombre = "Quebrada Honda" },
                new { IdBarrio = 27, Nombre = "Residencial" },
                new { IdBarrio = 28, Nombre = "San Cayetano de la Divina Providencia" },
                new { IdBarrio = 29, Nombre = "San José" },
                new { IdBarrio = 30, Nombre = "Spilimbergo" },
                new { IdBarrio = 31, Nombre = "Villa Aurora" },
                new { IdBarrio = 32, Nombre = "Villa Cabana" },
                new { IdBarrio = 33, Nombre = "Villa Díaz" },
                new { IdBarrio = 34, Nombre = "Villa Herbera" },
                new { IdBarrio = 35, Nombre = "Villa San Miguel" },
                new { IdBarrio = 36, Nombre = "Villa Tortosa" },
                new { IdBarrio = 37, Nombre = "Zona Desconocida" }
            };

            modelBuilder.Entity<Barrio>().HasData(barrios);
        }
    }
}
