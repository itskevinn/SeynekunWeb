using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class Migración : Migration
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
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Detalle = table.Column<string>(maxLength: 256, nullable: true),
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
                    Identificacion = table.Column<string>(maxLength: 30, nullable: false),
                    TipoIdentificacion = table.Column<string>(maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    NumeroTelefono2 = table.Column<string>(maxLength: 13, nullable: true),
                    Direccion = table.Column<string>(maxLength: 40, nullable: true),
                    Departamento = table.Column<string>(nullable: true),
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
                    Identificacion = table.Column<string>(maxLength: 30, nullable: false),
                    TipoIdentificacion = table.Column<string>(maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
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
                    TipoIdentificacion = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(maxLength: 20, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Fax = table.Column<string>(maxLength: 20, nullable: false),
                    SitioWeb = table.Column<string>(maxLength: 20, nullable: false),
                    Estado = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "FichasTecnicas",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    IdInsumo = table.Column<string>(maxLength: 20, nullable: false),
                    Ingrediente = table.Column<string>(maxLength: 20, nullable: false),
                    TipoIngrediente = table.Column<string>(maxLength: 20, nullable: false),
                    NumeroCas = table.Column<string>(maxLength: 20, nullable: false),
                    Observacion = table.Column<string>(maxLength: 20, nullable: true),
                    Ce = table.Column<string>(maxLength: 20, nullable: false),
                    Nop = table.Column<string>(maxLength: 20, nullable: false),
                    Jas = table.Column<string>(maxLength: 20, nullable: false),
                    Etapa = table.Column<string>(maxLength: 20, nullable: false),
                    Col = table.Column<string>(maxLength: 20, nullable: false),
                    Estado = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasTecnicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MateriasPrimas",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    UnidadMedida = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: false),
                    NombreProductor = table.Column<string>(nullable: true),
                    CodigoProductor = table.Column<string>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    EstadoMateria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasPrimas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Producciones",
                columns: table => new
                {
                    CodigoProduccion = table.Column<string>(maxLength: 20, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producciones", x => x.CodigoProduccion);
                });

            migrationBuilder.CreateTable(
                name: "Productores",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 30, nullable: false),
                    TipoIdentificacion = table.Column<string>(maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    CedulaCafetera = table.Column<string>(maxLength: 30, nullable: false),
                    NombrePredio = table.Column<string>(maxLength: 30, nullable: false),
                    CodigoFinca = table.Column<string>(maxLength: 30, nullable: false),
                    CodigoSica = table.Column<string>(maxLength: 30, nullable: false),
                    Municipio = table.Column<string>(maxLength: 20, nullable: true),
                    Vereda = table.Column<string>(maxLength: 30, nullable: false),
                    AfiliacionSalud = table.Column<string>(maxLength: 40, nullable: true),
                    NombreUsuario = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productores", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Transportadores",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: false),
                    NumeroLicencia = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadores", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    NombreUsuario = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(maxLength: 11, nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(maxLength: 25, nullable: false),
                    NumeroTelefono = table.Column<string>(maxLength: 13, nullable: true),
                    Email = table.Column<string>(maxLength: 30, nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.NombreUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    CodigoVenta = table.Column<string>(maxLength: 20, nullable: false),
                    EmpleadoId = table.Column<string>(nullable: false),
                    ClienteId = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Observacion = table.Column<string>(maxLength: 256, nullable: false),
                    TotalVenta = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.CodigoVenta);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Codigo = table.Column<string>(maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    ContenidoNeto = table.Column<decimal>(nullable: false),
                    UnidadMedida = table.Column<string>(maxLength: 13, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    NombreCategoria = table.Column<string>(maxLength: 17, nullable: true),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    IdFabricante = table.Column<string>(maxLength: 20, nullable: true),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Uso = table.Column<string>(maxLength: 20, nullable: false),
                    RegistroIca = table.Column<string>(maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 20, nullable: false),
                    Resultado = table.Column<string>(maxLength: 20, nullable: false),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    FichaTecnicaId = table.Column<string>(nullable: true),
                    FabricanteIdentificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insumos_Fabricantes_FabricanteIdentificacion",
                        column: x => x.FabricanteIdentificacion,
                        principalTable: "Fabricantes",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Insumos_FichasTecnicas_FichaTecnicaId",
                        column: x => x.FichaTecnicaId,
                        principalTable: "FichasTecnicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AjusteInventarios",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    CodigoMateriaPrima = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descipcion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<decimal>(nullable: false),
                    CodigoElemento = table.Column<string>(nullable: true),
                    CantidadMateriaPrima = table.Column<decimal>(nullable: false),
                    TipoAjuste = table.Column<string>(nullable: true),
                    NombreBodega = table.Column<string>(nullable: false),
                    TipoElemento = table.Column<string>(nullable: false),
                    BodegaNombre = table.Column<string>(nullable: true),
                    ProduccionCodigoProduccion = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_AjusteInventarios_Producciones_ProduccionCodigoProduccion",
                        column: x => x.ProduccionCodigoProduccion,
                        principalTable: "Producciones",
                        principalColumn: "CodigoProduccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallesVentas",
                columns: table => new
                {
                    codigoDetalle = table.Column<string>(maxLength: 20, nullable: false),
                    CodigoVenta = table.Column<string>(nullable: false),
                    CodigoProducto = table.Column<string>(nullable: false),
                    CantidadProducto = table.Column<decimal>(nullable: false),
                    TotalDetalle = table.Column<decimal>(nullable: false),
                    NombreBodega = table.Column<string>(nullable: false),
                    VentaCodigoVenta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesVentas", x => x.codigoDetalle);
                    table.ForeignKey(
                        name: "FK_DetallesVentas_Ventas_VentaCodigoVenta",
                        column: x => x.VentaCodigoVenta,
                        principalTable: "Ventas",
                        principalColumn: "CodigoVenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    IdInsumo = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Enlace = table.Column<string>(maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 20, nullable: true),
                    Estado = table.Column<string>(maxLength: 13, nullable: false),
                    InsumoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarios_BodegaNombre",
                table: "AjusteInventarios",
                column: "BodegaNombre");

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarios_ProduccionCodigoProduccion",
                table: "AjusteInventarios",
                column: "ProduccionCodigoProduccion");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVentas_VentaCodigoVenta",
                table: "DetallesVentas",
                column: "VentaCodigoVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_InsumoId",
                table: "Documentos",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_FabricanteIdentificacion",
                table: "Insumos",
                column: "FabricanteIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_FichaTecnicaId",
                table: "Insumos",
                column: "FichaTecnicaId");

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
                name: "DetallesVentas");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "MateriasPrimas");

            migrationBuilder.DropTable(
                name: "Productores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Transportadores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Bodegas");

            migrationBuilder.DropTable(
                name: "Producciones");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "FichasTecnicas");
        }
    }
}
