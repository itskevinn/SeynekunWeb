using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AjusteInventarios",
                columns: table => new
                {
                    Codigo = table.Column<string>(maxLength: 12, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descipcion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    CodigoElemento = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: false),
                    NombreBodega = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjusteInventarios", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AjusteInventarios");
        }
    }
}
