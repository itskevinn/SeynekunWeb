using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bodegas",
                columns: table => new
                {
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Detalle = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    Direccion = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodegas", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Detalle = table.Column<string>(maxLength: 200, nullable: true),
                    Estado = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Nombre);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 20, nullable: false),
                    TipoIdentificacion = table.Column<string>(maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(maxLength: 25, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    NumeroTelefono2 = table.Column<string>(maxLength: 13, nullable: true),
                    Direccion = table.Column<string>(maxLength: 40, nullable: true),
                    Departamento = table.Column<string>(maxLength: 14, nullable: true),
                    Municipio = table.Column<string>(nullable: true),
                    Barrio = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 20, nullable: false),
                    TipoIdentificacion = table.Column<string>(maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(maxLength: 25, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    Cargo = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 20, nullable: false),
                    TipoIdentificacion = table.Column<string>(maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(maxLength: 25, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    SitioWeb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "MateriasPrimas",
                columns: table => new
                {
                    Codigo = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    UnidadMedida = table.Column<string>(maxLength: 20, nullable: false),
                    CodigoProductor = table.Column<string>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasPrimas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Productores",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 20, nullable: false),
                    TipoIdentificacion = table.Column<string>(maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(maxLength: 25, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    CedulaCafetera = table.Column<string>(maxLength: 20, nullable: false),
                    NombrePredio = table.Column<string>(maxLength: 30, nullable: false),
                    CodigoFinca = table.Column<string>(maxLength: 15, nullable: false),
                    CodigoSica = table.Column<string>(maxLength: 15, nullable: false),
                    Municipio = table.Column<string>(maxLength: 20, nullable: false),
                    Vereda = table.Column<string>(maxLength: 20, nullable: false),
                    AfiliacionSalud = table.Column<string>(maxLength: 30, nullable: false),
                    NombreUsuario = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productores", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    NombreUsuario = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(maxLength: 11, nullable: false),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(maxLength: 25, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.NombreUsuario);
                });

            migrationBuilder.CreateTable(
                name: "AjusteInventarios",
                columns: table => new
                {
                    Codigo = table.Column<decimal>(nullable: false),
                    CodigoMateriaPrima = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descipcion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<decimal>(nullable: false),
                    CodigoElemento = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: false),
                    NombreBodega = table.Column<string>(nullable: false),
                    BodegaNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjusteInventarios", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_AjusteInventarios_Bodegas_BodegaNombre",
                        column: x => x.BodegaNombre,
                        principalTable: "Bodegas",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Codigo = table.Column<string>(maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    NombreCategoria = table.Column<string>(maxLength: 17, nullable: true),
                    Cantidad = table.Column<decimal>(nullable: false),
                    UnidadMedida = table.Column<string>(maxLength: 13, nullable: false),
                    CategoriaNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaNombre",
                        column: x => x.CategoriaNombre,
                        principalTable: "Categorias",
                        principalColumn: "Nombre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarios_BodegaNombre",
                table: "AjusteInventarios",
                column: "BodegaNombre");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaNombre",
                table: "Productos",
                column: "CategoriaNombre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AjusteInventarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "MateriasPrimas");

            migrationBuilder.DropTable(
                name: "Productores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Bodegas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
