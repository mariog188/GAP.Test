using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GAP.Test.Domain.Infraestructure.Migrations
{
    public partial class defaultDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "fechainicio",
                table: "poliza",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "fechainicio",
                table: "poliza",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
