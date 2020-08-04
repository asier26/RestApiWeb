using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWeb.Migrations
{
    public partial class crearbbdd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname1",
                table: "Categoria");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Categoria",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Categoria",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                table: "Categoria",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Categoria");

            migrationBuilder.AlterColumn<int>(
                name: "Surname",
                table: "Categoria",
                type: "int",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Categoria",
                type: "bit",
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "Surname1",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
