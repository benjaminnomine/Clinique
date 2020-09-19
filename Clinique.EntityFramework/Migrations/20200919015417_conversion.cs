using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinique.EntityFramework.Migrations
{
    public partial class conversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TypeCompte",
                table: "Utilisateurs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TypeCompte",
                table: "Utilisateurs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
