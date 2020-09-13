using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinique.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordonnances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOrd = table.Column<int>(nullable: false),
                    Recommandations = table.Column<string>(nullable: true),
                    TypeO = table.Column<string>(nullable: false),
                    DateC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordonnances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMed = table.Column<int>(nullable: false),
                    NomMed = table.Column<string>(nullable: true),
                    Prix = table.Column<double>(nullable: false),
                    IdCategorie = table.Column<int>(nullable: false),
                    CategorieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicaments_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordonnancechirurgies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOrd = table.Column<int>(nullable: false),
                    Rang = table.Column<int>(nullable: false),
                    NomChirurgie = table.Column<string>(nullable: true),
                    OrdonnanceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordonnancechirurgies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordonnancechirurgies_Ordonnances_OrdonnanceId",
                        column: x => x.OrdonnanceId,
                        principalTable: "Ordonnances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Docteurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<int>(nullable: false),
                    NomM = table.Column<string>(nullable: true),
                    PrenomM = table.Column<string>(nullable: true),
                    IdSpecialite = table.Column<int>(nullable: false),
                    SpecialiteId = table.Column<int>(nullable: true),
                    Ville = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Niveau = table.Column<string>(nullable: false),
                    NbrPatients = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docteurs_Specialites_SpecialiteId",
                        column: x => x.SpecialiteId,
                        principalTable: "Specialites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordonnancemedicaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumOrd = table.Column<int>(nullable: false),
                    IdMed = table.Column<int>(nullable: false),
                    NbBoites = table.Column<int>(nullable: false),
                    OrdonnanceId = table.Column<int>(nullable: true),
                    MedicamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordonnancemedicaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordonnancemedicaments_Medicaments_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordonnancemedicaments_Ordonnances_OrdonnanceId",
                        column: x => x.OrdonnanceId,
                        principalTable: "Ordonnances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dossierpatients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumDos = table.Column<int>(nullable: false),
                    NomP = table.Column<string>(nullable: true),
                    PrenomP = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: false),
                    NumAS = table.Column<int>(nullable: false),
                    DateNaiss = table.Column<DateTime>(nullable: false),
                    DateC = table.Column<DateTime>(nullable: false),
                    Matricule = table.Column<int>(nullable: false),
                    DocteurId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossierpatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dossierpatients_Docteurs_DocteurId",
                        column: x => x.DocteurId,
                        principalTable: "Docteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeDocteur = table.Column<int>(nullable: false),
                    NumDos = table.Column<int>(nullable: false),
                    DateC = table.Column<DateTime>(nullable: false),
                    Diagnostic = table.Column<string>(nullable: true),
                    NumOrd = table.Column<int>(nullable: false),
                    OrdonnanceId = table.Column<int>(nullable: true),
                    DocteurId = table.Column<int>(nullable: true),
                    DossierpatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_Docteurs_DocteurId",
                        column: x => x.DocteurId,
                        principalTable: "Docteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultations_Dossierpatients_DossierpatientId",
                        column: x => x.DossierpatientId,
                        principalTable: "Dossierpatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultations_Ordonnances_OrdonnanceId",
                        column: x => x.OrdonnanceId,
                        principalTable: "Ordonnances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_DocteurId",
                table: "Consultations",
                column: "DocteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_DossierpatientId",
                table: "Consultations",
                column: "DossierpatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_OrdonnanceId",
                table: "Consultations",
                column: "OrdonnanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Docteurs_SpecialiteId",
                table: "Docteurs",
                column: "SpecialiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Dossierpatients_DocteurId",
                table: "Dossierpatients",
                column: "DocteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_CategorieId",
                table: "Medicaments",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordonnancechirurgies_OrdonnanceId",
                table: "Ordonnancechirurgies",
                column: "OrdonnanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordonnancemedicaments_MedicamentId",
                table: "Ordonnancemedicaments",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordonnancemedicaments_OrdonnanceId",
                table: "Ordonnancemedicaments",
                column: "OrdonnanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Ordonnancechirurgies");

            migrationBuilder.DropTable(
                name: "Ordonnancemedicaments");

            migrationBuilder.DropTable(
                name: "Dossierpatients");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Ordonnances");

            migrationBuilder.DropTable(
                name: "Docteurs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Specialites");
        }
    }
}
