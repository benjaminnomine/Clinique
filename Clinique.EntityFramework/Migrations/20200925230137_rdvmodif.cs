using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinique.EntityFramework.Migrations
{
    public partial class rdvmodif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_RendezVous_DateRdv_IdDocteur_IdDossierpatient",
                table: "RendezVous");

            migrationBuilder.DropColumn(
                name: "DateFin",
                table: "RendezVous");

            migrationBuilder.DropColumn(
                name: "DateRdv",
                table: "RendezVous");

            migrationBuilder.DropColumn(
                name: "Duree",
                table: "RendezVous");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RendezVous_Start_IdDocteur_IdDossierpatient",
                table: "RendezVous",
                columns: new[] { "Start", "IdDocteur", "IdDossierpatient" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_RendezVous_Start_IdDocteur_IdDossierpatient",
                table: "RendezVous");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFin",
                table: "RendezVous",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRdv",
                table: "RendezVous",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Duree",
                table: "RendezVous",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RendezVous_DateRdv_IdDocteur_IdDossierpatient",
                table: "RendezVous",
                columns: new[] { "DateRdv", "IdDocteur", "IdDossierpatient" });
        }
    }
}
