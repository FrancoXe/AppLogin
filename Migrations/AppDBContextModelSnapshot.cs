﻿// <auto-generated />
using System;
using AppLogin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppLogin.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppLogin.Models.Barrio", b =>
                {
                    b.Property<int>("IdBarrio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBarrio"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdBarrio");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Barrios");

                    b.HasData(
                        new
                        {
                            IdBarrio = 1,
                            Nombre = "Todos"
                        },
                        new
                        {
                            IdBarrio = 2,
                            Nombre = "Alto Alegre"
                        },
                        new
                        {
                            IdBarrio = 3,
                            Nombre = "Centro"
                        },
                        new
                        {
                            IdBarrio = 4,
                            Nombre = "Cigarrales A"
                        },
                        new
                        {
                            IdBarrio = 5,
                            Nombre = "Cigarrales B"
                        },
                        new
                        {
                            IdBarrio = 6,
                            Nombre = "Cigarrales C"
                        },
                        new
                        {
                            IdBarrio = 7,
                            Nombre = "Cigarrales de Santa Rosa"
                        },
                        new
                        {
                            IdBarrio = 8,
                            Nombre = "Corral de Barrancas"
                        },
                        new
                        {
                            IdBarrio = 9,
                            Nombre = "Forchieri"
                        },
                        new
                        {
                            IdBarrio = 10,
                            Nombre = "Gobernador Pizarro"
                        },
                        new
                        {
                            IdBarrio = 11,
                            Nombre = "IPV 20 Viviendas"
                        },
                        new
                        {
                            IdBarrio = 12,
                            Nombre = "IPV 34 Viviendas"
                        },
                        new
                        {
                            IdBarrio = 13,
                            Nombre = "La Loma"
                        },
                        new
                        {
                            IdBarrio = 14,
                            Nombre = "La Providencia"
                        },
                        new
                        {
                            IdBarrio = 15,
                            Nombre = "Las Corzuelas"
                        },
                        new
                        {
                            IdBarrio = 16,
                            Nombre = "Las Ensenadas"
                        },
                        new
                        {
                            IdBarrio = 17,
                            Nombre = "Las Higueras"
                        },
                        new
                        {
                            IdBarrio = 18,
                            Nombre = "Las Mercedes"
                        },
                        new
                        {
                            IdBarrio = 19,
                            Nombre = "Lomas del Zupay"
                        },
                        new
                        {
                            IdBarrio = 20,
                            Nombre = "Los Talitas"
                        },
                        new
                        {
                            IdBarrio = 21,
                            Nombre = "Mutual"
                        },
                        new
                        {
                            IdBarrio = 22,
                            Nombre = "Norte"
                        },
                        new
                        {
                            IdBarrio = 23,
                            Nombre = "Pajas Blancas"
                        },
                        new
                        {
                            IdBarrio = 24,
                            Nombre = "Parque Serrano"
                        },
                        new
                        {
                            IdBarrio = 25,
                            Nombre = "Progreso"
                        },
                        new
                        {
                            IdBarrio = 26,
                            Nombre = "Quebrada Honda"
                        },
                        new
                        {
                            IdBarrio = 27,
                            Nombre = "Residencial"
                        },
                        new
                        {
                            IdBarrio = 28,
                            Nombre = "San Cayetano de la Divina Providencia"
                        },
                        new
                        {
                            IdBarrio = 29,
                            Nombre = "San José"
                        },
                        new
                        {
                            IdBarrio = 30,
                            Nombre = "Spilimbergo"
                        },
                        new
                        {
                            IdBarrio = 31,
                            Nombre = "Villa Aurora"
                        },
                        new
                        {
                            IdBarrio = 32,
                            Nombre = "Villa Cabana"
                        },
                        new
                        {
                            IdBarrio = 33,
                            Nombre = "Villa Díaz"
                        },
                        new
                        {
                            IdBarrio = 34,
                            Nombre = "Villa Herbera"
                        },
                        new
                        {
                            IdBarrio = 35,
                            Nombre = "Villa San Miguel"
                        },
                        new
                        {
                            IdBarrio = 36,
                            Nombre = "Villa Tortosa"
                        },
                        new
                        {
                            IdBarrio = 37,
                            Nombre = "Zona Desconocida"
                        });
                });

            modelBuilder.Entity("AppLogin.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdCategoria");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            IdCategoria = 1,
                            Nombre = "Alumbrado público"
                        },
                        new
                        {
                            IdCategoria = 2,
                            Nombre = "Calles rutas"
                        },
                        new
                        {
                            IdCategoria = 3,
                            Nombre = "Cartelería y señales"
                        },
                        new
                        {
                            IdCategoria = 4,
                            Nombre = "Comercio"
                        },
                        new
                        {
                            IdCategoria = 5,
                            Nombre = "Desarrollo comunitario"
                        },
                        new
                        {
                            IdCategoria = 6,
                            Nombre = "Higiene urbana basura en calle"
                        },
                        new
                        {
                            IdCategoria = 7,
                            Nombre = "Intendencia"
                        },
                        new
                        {
                            IdCategoria = 8,
                            Nombre = "Notas varios"
                        },
                        new
                        {
                            IdCategoria = 9,
                            Nombre = "Ambiente libre de humo"
                        },
                        new
                        {
                            IdCategoria = 10,
                            Nombre = "Poscovid"
                        },
                        new
                        {
                            IdCategoria = 11,
                            Nombre = "Reparto de agua"
                        },
                        new
                        {
                            IdCategoria = 12,
                            Nombre = "Salud"
                        },
                        new
                        {
                            IdCategoria = 13,
                            Nombre = "Seguridad"
                        },
                        new
                        {
                            IdCategoria = 14,
                            Nombre = "Sistemas"
                        });
                });

            modelBuilder.Entity("AppLogin.Models.Notificacion", b =>
                {
                    b.Property<int>("IdNotificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNotificacion"));

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("Leida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdNotificacion");

                    b.HasIndex("FechaCreacion");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("Leida");

                    b.ToTable("Notificaciones");
                });

            modelBuilder.Entity("AppLogin.Models.Reclamo", b =>
                {
                    b.Property<int>("IdReclamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReclamo"));

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("IdBarrio")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdSubcategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("RutaArchivo")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdReclamo");

                    b.HasIndex("DNI");

                    b.HasIndex("Estado");

                    b.HasIndex("FechaCreacion");

                    b.HasIndex("IdBarrio");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdSubcategoria");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Reclamos");
                });

            modelBuilder.Entity("AppLogin.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdRol");

                    b.HasIndex("NombreRol")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            IdRol = 1,
                            NombreRol = "Vecino"
                        },
                        new
                        {
                            IdRol = 2,
                            NombreRol = "Administrador"
                        },
                        new
                        {
                            IdRol = 3,
                            NombreRol = "Departamento"
                        });
                });

            modelBuilder.Entity("AppLogin.Models.Subcategoria", b =>
                {
                    b.Property<int>("IdSubcategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSubcategoria"));

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSubcategoria");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("Nombre", "IdCategoria")
                        .IsUnique();

                    b.ToTable("Subcategorias");

                    b.HasData(
                        new
                        {
                            IdSubcategoria = 1,
                            IdCategoria = 1,
                            Nombre = "Luminaria no funciona"
                        },
                        new
                        {
                            IdSubcategoria = 2,
                            IdCategoria = 1,
                            Nombre = "Poste caído"
                        },
                        new
                        {
                            IdSubcategoria = 3,
                            IdCategoria = 1,
                            Nombre = "Zona oscura"
                        },
                        new
                        {
                            IdSubcategoria = 4,
                            IdCategoria = 1,
                            Nombre = "Otros"
                        },
                        new
                        {
                            IdSubcategoria = 5,
                            IdCategoria = 2,
                            Nombre = "Baches"
                        },
                        new
                        {
                            IdSubcategoria = 6,
                            IdCategoria = 2,
                            Nombre = "Asfalto dañado"
                        },
                        new
                        {
                            IdSubcategoria = 7,
                            IdCategoria = 2,
                            Nombre = "Arreglo de calles"
                        },
                        new
                        {
                            IdSubcategoria = 8,
                            IdCategoria = 2,
                            Nombre = "Cordon cuneta"
                        },
                        new
                        {
                            IdSubcategoria = 9,
                            IdCategoria = 2,
                            Nombre = "Limpieza de cordon cuneta"
                        },
                        new
                        {
                            IdSubcategoria = 10,
                            IdCategoria = 2,
                            Nombre = "Reductores de velocidad"
                        },
                        new
                        {
                            IdSubcategoria = 11,
                            IdCategoria = 2,
                            Nombre = "Riego de calles"
                        },
                        new
                        {
                            IdSubcategoria = 12,
                            IdCategoria = 3,
                            Nombre = "Cartelería dañado"
                        },
                        new
                        {
                            IdSubcategoria = 13,
                            IdCategoria = 3,
                            Nombre = "Semáforo"
                        },
                        new
                        {
                            IdSubcategoria = 14,
                            IdCategoria = 4,
                            Nombre = "Certificado de comercio"
                        },
                        new
                        {
                            IdSubcategoria = 15,
                            IdCategoria = 5,
                            Nombre = "Modulos alimentarios"
                        },
                        new
                        {
                            IdSubcategoria = 16,
                            IdCategoria = 6,
                            Nombre = "Limpieza y barrido"
                        },
                        new
                        {
                            IdSubcategoria = 17,
                            IdCategoria = 6,
                            Nombre = "Agua servida"
                        },
                        new
                        {
                            IdSubcategoria = 18,
                            IdCategoria = 6,
                            Nombre = "Escombros"
                        },
                        new
                        {
                            IdSubcategoria = 19,
                            IdCategoria = 6,
                            Nombre = "Microbasurales"
                        },
                        new
                        {
                            IdSubcategoria = 20,
                            IdCategoria = 6,
                            Nombre = "Animales muertos"
                        },
                        new
                        {
                            IdSubcategoria = 21,
                            IdCategoria = 6,
                            Nombre = "Poda y extracción"
                        },
                        new
                        {
                            IdSubcategoria = 22,
                            IdCategoria = 6,
                            Nombre = "Recolección de residuos comunes"
                        },
                        new
                        {
                            IdSubcategoria = 23,
                            IdCategoria = 6,
                            Nombre = "Recolección de residuos diferenciados"
                        },
                        new
                        {
                            IdSubcategoria = 24,
                            IdCategoria = 6,
                            Nombre = "Recolección de poda"
                        },
                        new
                        {
                            IdSubcategoria = 25,
                            IdCategoria = 6,
                            Nombre = "Desmalezados"
                        },
                        new
                        {
                            IdSubcategoria = 26,
                            IdCategoria = 6,
                            Nombre = "Estado higiénico de terreno"
                        },
                        new
                        {
                            IdSubcategoria = 27,
                            IdCategoria = 7,
                            Nombre = "Oficios"
                        },
                        new
                        {
                            IdSubcategoria = 28,
                            IdCategoria = 7,
                            Nombre = "Notas"
                        },
                        new
                        {
                            IdSubcategoria = 29,
                            IdCategoria = 7,
                            Nombre = "Ordenanzas"
                        },
                        new
                        {
                            IdSubcategoria = 30,
                            IdCategoria = 8,
                            Nombre = "Otros"
                        },
                        new
                        {
                            IdSubcategoria = 31,
                            IdCategoria = 9,
                            Nombre = "Olor a humo en el ambiente"
                        },
                        new
                        {
                            IdSubcategoria = 32,
                            IdCategoria = 9,
                            Nombre = "Personas fumando"
                        },
                        new
                        {
                            IdSubcategoria = 33,
                            IdCategoria = 9,
                            Nombre = "Venta de cigarrillos a menores de edad"
                        },
                        new
                        {
                            IdSubcategoria = 34,
                            IdCategoria = 9,
                            Nombre = "Publicidad en lugares no correspondidos"
                        },
                        new
                        {
                            IdSubcategoria = 35,
                            IdCategoria = 10,
                            Nombre = "En análisis"
                        },
                        new
                        {
                            IdSubcategoria = 36,
                            IdCategoria = 10,
                            Nombre = "Fallecido"
                        },
                        new
                        {
                            IdSubcategoria = 37,
                            IdCategoria = 11,
                            Nombre = "Reparto de agua"
                        },
                        new
                        {
                            IdSubcategoria = 38,
                            IdCategoria = 11,
                            Nombre = "Reparto de agua a cabana"
                        },
                        new
                        {
                            IdSubcategoria = 39,
                            IdCategoria = 12,
                            Nombre = "Centro de salud forchieri"
                        },
                        new
                        {
                            IdSubcategoria = 40,
                            IdCategoria = 12,
                            Nombre = "Centro de salud san Miguel"
                        },
                        new
                        {
                            IdSubcategoria = 41,
                            IdCategoria = 12,
                            Nombre = "Centro de salud Pizarro"
                        },
                        new
                        {
                            IdSubcategoria = 42,
                            IdCategoria = 12,
                            Nombre = "Centro de salud quebrada onda"
                        },
                        new
                        {
                            IdSubcategoria = 43,
                            IdCategoria = 12,
                            Nombre = "Centro de salud cabana"
                        },
                        new
                        {
                            IdSubcategoria = 44,
                            IdCategoria = 13,
                            Nombre = "Animales sueltos"
                        },
                        new
                        {
                            IdSubcategoria = 45,
                            IdCategoria = 13,
                            Nombre = "Ruidos molestos"
                        },
                        new
                        {
                            IdSubcategoria = 46,
                            IdCategoria = 13,
                            Nombre = "Otros"
                        },
                        new
                        {
                            IdSubcategoria = 47,
                            IdCategoria = 14,
                            Nombre = "Gestión de cedulones"
                        });
                });

            modelBuilder.Entity("AppLogin.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UltimoAcceso")
                        .HasColumnType("datetime2");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Correo")
                        .IsUnique();

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AppLogin.Models.Notificacion", b =>
                {
                    b.HasOne("AppLogin.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AppLogin.Models.Reclamo", b =>
                {
                    b.HasOne("AppLogin.Models.Barrio", "Barrio")
                        .WithMany()
                        .HasForeignKey("IdBarrio")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppLogin.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppLogin.Models.Subcategoria", "Subcategoria")
                        .WithMany()
                        .HasForeignKey("IdSubcategoria")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppLogin.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Barrio");

                    b.Navigation("Categoria");

                    b.Navigation("Subcategoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AppLogin.Models.Subcategoria", b =>
                {
                    b.HasOne("AppLogin.Models.Categoria", "Categoria")
                        .WithMany("Subcategorias")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("AppLogin.Models.Usuario", b =>
                {
                    b.HasOne("AppLogin.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("AppLogin.Models.Categoria", b =>
                {
                    b.Navigation("Subcategorias");
                });
#pragma warning restore 612, 618
        }
    }
}
