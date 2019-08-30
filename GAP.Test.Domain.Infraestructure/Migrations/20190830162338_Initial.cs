using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAP.Test.Domain.Infraestructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    apellido = table.Column<string>(maxLength: 30, nullable: false),
                    cedula = table.Column<int>(nullable: false),
                    fechanacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipocubrimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(maxLength: 30, nullable: false),
                    Porcentaje = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipocubrimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tiporiesgo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tiporiesgo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "poliza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(maxLength: 30, nullable: false),
                    fechainicio = table.Column<DateTime>(nullable: false),
                    periodocobertura = table.Column<int>(nullable: false),
                    precio = table.Column<decimal>(nullable: false),
                    IdTipoCubrimiento = table.Column<int>(nullable: false),
                    IdTipoRiesgo = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poliza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_poliza_cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_poliza_tipocubrimiento_IdTipoCubrimiento",
                        column: x => x.IdTipoCubrimiento,
                        principalTable: "tipocubrimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_poliza_tiporiesgo_IdTipoRiesgo",
                        column: x => x.IdTipoRiesgo,
                        principalTable: "tiporiesgo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_poliza_IdCliente",
                table: "poliza",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_poliza_IdTipoCubrimiento",
                table: "poliza",
                column: "IdTipoCubrimiento");

            migrationBuilder.CreateIndex(
                name: "IX_poliza_IdTipoRiesgo",
                table: "poliza",
                column: "IdTipoRiesgo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "poliza");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "tipocubrimiento");

            migrationBuilder.DropTable(
                name: "tiporiesgo");
        }
    }
}
