using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteTecnico.Infrastructure.Migrations
{
    public partial class ChangePropertiesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SobreNome",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "User",
                newName: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "SobreNome");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "Nome");
        }
    }
}
