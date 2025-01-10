using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppLogin.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCategoriasBarrios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamo_Usuario_UsuarioId",
                table: "Reclamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Roles_IdRol",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reclamo",
                table: "Reclamo");

            migrationBuilder.DropColumn(
                name: "Barrio",
                table: "Reclamo");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Reclamo");

            migrationBuilder.DropColumn(
                name: "Subcategoria",
                table: "Reclamo");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Reclamo",
                newName: "Reclamos");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuarios",
                newName: "IX_Usuarios_IdRol");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Reclamos",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reclamos",
                newName: "IdReclamo");

            migrationBuilder.RenameIndex(
                name: "IX_Reclamo_UsuarioId",
                table: "Reclamos",
                newName: "IX_Reclamos_IdUsuario");

            migrationBuilder.AlterColumn<string>(
                name: "RutaArchivo",
                table: "Reclamos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Reclamos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Pendiente");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Reclamos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "Reclamos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<int>(
                name: "IdBarrio",
                table: "Reclamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Reclamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSubcategoria",
                table: "Reclamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reclamos",
                table: "Reclamos",
                column: "IdReclamo");

            migrationBuilder.CreateTable(
                name: "Barrios",
                columns: table => new
                {
                    IdBarrio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrios", x => x.IdBarrio);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Subcategorias",
                columns: table => new
                {
                    IdSubcategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategorias", x => x.IdSubcategoria);
                    table.ForeignKey(
                        name: "FK_Subcategorias_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Barrios",
                columns: new[] { "IdBarrio", "Nombre" },
                values: new object[,]
                {
                    { 1, "Todos" },
                    { 2, "Alto Alegre" },
                    { 3, "Centro" },
                    { 4, "Cigarrales A" },
                    { 5, "Cigarrales B" },
                    { 6, "Cigarrales C" },
                    { 7, "Cigarrales de Santa Rosa" },
                    { 8, "Corral de Barrancas" },
                    { 9, "Forchieri" },
                    { 10, "Gobernador Pizarro" },
                    { 11, "IPV 20 Viviendas" },
                    { 12, "IPV 34 Viviendas" },
                    { 13, "La Loma" },
                    { 14, "La Providencia" },
                    { 15, "Las Corzuelas" },
                    { 16, "Las Ensenadas" },
                    { 17, "Las Higueras" },
                    { 18, "Las Mercedes" },
                    { 19, "Lomas del Zupay" },
                    { 20, "Los Talitas" },
                    { 21, "Mutual" },
                    { 22, "Norte" },
                    { 23, "Pajas Blancas" },
                    { 24, "Parque Serrano" },
                    { 25, "Progreso" },
                    { 26, "Quebrada Honda" },
                    { 27, "Residencial" },
                    { 28, "San Cayetano de la Divina Providencia" },
                    { 29, "San José" },
                    { 30, "Spilimbergo" },
                    { 31, "Villa Aurora" },
                    { 32, "Villa Cabana" },
                    { 33, "Villa Díaz" },
                    { 34, "Villa Herbera" },
                    { 35, "Villa San Miguel" },
                    { 36, "Villa Tortosa" },
                    { 37, "Zona Desconocida" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { 1, "Alumbrado público" },
                    { 2, "Calles rutas" },
                    { 3, "Cartelería y señales" },
                    { 4, "Comercio" },
                    { 5, "Desarrollo comunitario" },
                    { 6, "Higiene urbana basura en calle" },
                    { 7, "Intendencia" },
                    { 8, "Notas varios" },
                    { 9, "Ambiente libre de humo" },
                    { 10, "Poscovid" },
                    { 11, "Reparto de agua" },
                    { 12, "Salud" },
                    { 13, "Seguridad" },
                    { 14, "Sistemas" }
                });

            migrationBuilder.InsertData(
                table: "Subcategorias",
                columns: new[] { "IdSubcategoria", "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Luminaria no funciona" },
                    { 2, 1, "Poste caído" },
                    { 3, 1, "Zona oscura" },
                    { 4, 1, "Otros" },
                    { 5, 2, "Baches" },
                    { 6, 2, "Asfalto dañado" },
                    { 7, 2, "Arreglo de calles" },
                    { 8, 2, "Cordon cuneta" },
                    { 9, 2, "Limpieza de cordon cuneta" },
                    { 10, 2, "Reductores de velocidad" },
                    { 11, 2, "Riego de calles" },
                    { 12, 3, "Cartelería dañado" },
                    { 13, 3, "Semáforo" },
                    { 14, 4, "Certificado de comercio" },
                    { 15, 5, "Modulos alimentarios" },
                    { 16, 6, "Limpieza y barrido" },
                    { 17, 6, "Agua servida" },
                    { 18, 6, "Escombros" },
                    { 19, 6, "Microbasurales" },
                    { 20, 6, "Animales muertos" },
                    { 21, 6, "Poda y extracción" },
                    { 22, 6, "Recolección de residuos comunes" },
                    { 23, 6, "Recolección de residuos diferenciados" },
                    { 24, 6, "Recolección de poda" },
                    { 25, 6, "Desmalezados" },
                    { 26, 6, "Estado higiénico de terreno" },
                    { 27, 7, "Oficios" },
                    { 28, 7, "Notas" },
                    { 29, 7, "Ordenanzas" },
                    { 30, 8, "Otros" },
                    { 31, 9, "Olor a humo en el ambiente" },
                    { 32, 9, "Personas fumando" },
                    { 33, 9, "Venta de cigarrillos a menores de edad" },
                    { 34, 9, "Publicidad en lugares no correspondidos" },
                    { 35, 10, "En análisis" },
                    { 36, 10, "Fallecido" },
                    { 37, 11, "Reparto de agua" },
                    { 38, 11, "Reparto de agua a cabana" },
                    { 39, 12, "Centro de salud forchieri" },
                    { 40, 12, "Centro de salud san Miguel" },
                    { 41, 12, "Centro de salud Pizarro" },
                    { 42, 12, "Centro de salud quebrada onda" },
                    { 43, 12, "Centro de salud cabana" },
                    { 44, 13, "Animales sueltos" },
                    { 45, 13, "Ruidos molestos" },
                    { 46, 13, "Otros" },
                    { 47, 14, "Gestión de cedulones" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_IdBarrio",
                table: "Reclamos",
                column: "IdBarrio");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_IdCategoria",
                table: "Reclamos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_IdSubcategoria",
                table: "Reclamos",
                column: "IdSubcategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategorias_IdCategoria",
                table: "Subcategorias",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_Barrios_IdBarrio",
                table: "Reclamos",
                column: "IdBarrio",
                principalTable: "Barrios",
                principalColumn: "IdBarrio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_Categorias_IdCategoria",
                table: "Reclamos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_Subcategorias_IdSubcategoria",
                table: "Reclamos",
                column: "IdSubcategoria",
                principalTable: "Subcategorias",
                principalColumn: "IdSubcategoria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_Usuarios_IdUsuario",
                table: "Reclamos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_IdRol",
                table: "Usuarios",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_Barrios_IdBarrio",
                table: "Reclamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_Categorias_IdCategoria",
                table: "Reclamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_Subcategorias_IdSubcategoria",
                table: "Reclamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_Usuarios_IdUsuario",
                table: "Reclamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_IdRol",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Barrios");

            migrationBuilder.DropTable(
                name: "Subcategorias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reclamos",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_IdBarrio",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_IdCategoria",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_IdSubcategoria",
                table: "Reclamos");

            migrationBuilder.DropColumn(
                name: "IdBarrio",
                table: "Reclamos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Reclamos");

            migrationBuilder.DropColumn(
                name: "IdSubcategoria",
                table: "Reclamos");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Reclamos",
                newName: "Reclamo");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuario",
                newName: "IX_Usuario_IdRol");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Reclamo",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdReclamo",
                table: "Reclamo",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Reclamos_IdUsuario",
                table: "Reclamo",
                newName: "IX_Reclamo_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "RutaArchivo",
                table: "Reclamo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Reclamo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Pendiente",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Reclamo",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DNI",
                table: "Reclamo",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Barrio",
                table: "Reclamo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Reclamo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subcategoria",
                table: "Reclamo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reclamo",
                table: "Reclamo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamo_Usuario_UsuarioId",
                table: "Reclamo",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Roles_IdRol",
                table: "Usuario",
                column: "IdRol",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
