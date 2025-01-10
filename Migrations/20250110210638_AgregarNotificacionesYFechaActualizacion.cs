using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppLogin.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNotificacionesYFechaActualizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Reclamos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    IdNotificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Leida = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.IdNotificacion);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcategorias_Nombre_IdCategoria",
                table: "Subcategorias",
                columns: new[] { "Nombre", "IdCategoria" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_NombreRol",
                table: "Roles",
                column: "NombreRol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_DNI",
                table: "Reclamos",
                column: "DNI");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_Estado",
                table: "Reclamos",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_FechaCreacion",
                table: "Reclamos",
                column: "FechaCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Nombre",
                table: "Categorias",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_Nombre",
                table: "Barrios",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_FechaCreacion",
                table: "Notificaciones",
                column: "FechaCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_IdUsuario",
                table: "Notificaciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_Leida",
                table: "Notificaciones",
                column: "Leida");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Subcategorias_Nombre_IdCategoria",
                table: "Subcategorias");

            migrationBuilder.DropIndex(
                name: "IX_Roles_NombreRol",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_DNI",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_Estado",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_FechaCreacion",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_Nombre",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Barrios_Nombre",
                table: "Barrios");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Reclamos");
        }
    }
}
