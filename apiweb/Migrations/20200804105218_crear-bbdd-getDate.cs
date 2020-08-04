using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWeb.Migrations
{
    public partial class crearbbddgetDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Categoria",
                unicode: false,
                maxLength: 20,
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldUnicode: false,
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Categoria",
                type: "datetime2",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldUnicode: false,
                oldMaxLength: 20,
                oldDefaultValueSql: "getdate()");
        }
    }
}
