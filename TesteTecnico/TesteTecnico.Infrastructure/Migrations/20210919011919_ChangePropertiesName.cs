using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteTecnico.Infrastructure.Migrations
{
    public partial class ChangePropertiesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SchoolingId",
                table: "User",
                newName: "EscolaridadeId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "User",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "User",
                newName: "DataNascimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "EscolaridadeId",
                table: "User",
                newName: "SchoolingId");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "User",
                newName: "BirthDate");
        }
    }
}
