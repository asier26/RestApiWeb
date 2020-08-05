using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiWeb.Migrations
{
    public partial class newdb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Estate",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "customer");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "customer",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "customer",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "customer",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "customer",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "customer",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "customer",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "customer",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Email",
                table: "customer",
                newName: "IX_customer_email");

            migrationBuilder.AddColumn<bool>(
                name: "state",
                table: "customer",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "customerId");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<int>(nullable: false),
                    UserValid = table.Column<bool>(nullable: false),
                    State = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "state",
                table: "customer");

            migrationBuilder.RenameTable(
                name: "customer",
                newName: "Customer");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Customer",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "Customer",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Customer",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Customer",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Customer",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Customer",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_customer_email",
                table: "Customer",
                newName: "IX_Customer_Email");

            migrationBuilder.AddColumn<bool>(
                name: "Estate",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValueSql: "((1))");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");
        }
    }
}
