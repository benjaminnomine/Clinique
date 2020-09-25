using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinique.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    TypeCompte = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomMed = table.Column<string>(nullable: true),
                    Prix = table.Column<double>(nullable: false),
                    IdCategorie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicaments_Categories_IdCategorie",
                        column: x => x.IdCategorie,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordonnancechirurgies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rang = table.Column<int>(nullable: false),
                    NomChirurgie = table.Column<string>(nullable: true),
                    IdOrdonnance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordonnancechirurgies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordonnancechirurgies_Ordonnances_IdOrdonnance",
                        column: x => x.IdOrdonnance,
                        principalTable: "Ordonnances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Ville = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Niveau = table.Column<string>(nullable: false),
                    NbrPatients = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docteurs_Specialites_IdSpecialite",
                        column: x => x.IdSpecialite,
                        principalTable: "Specialites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordonnancemedicaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbBoites = table.Column<int>(nullable: false),
                    IdOrdonnance = table.Column<int>(nullable: false),
                    IdMedicament = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordonnancemedicaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordonnancemedicaments_Medicaments_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordonnancemedicaments_Ordonnances_IdOrdonnance",
                        column: x => x.IdOrdonnance,
                        principalTable: "Ordonnances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dossierpatients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomP = table.Column<string>(nullable: true),
                    PrenomP = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: false),
                    NumAS = table.Column<int>(nullable: false),
                    DateNaiss = table.Column<DateTime>(nullable: false),
                    DateC = table.Column<DateTime>(nullable: false),
                    IdDocteur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossierpatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dossierpatients_Docteurs_IdDocteur",
                        column: x => x.IdDocteur,
                        principalTable: "Docteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDocteur = table.Column<int>(nullable: false),
                    IdDossierpatient = table.Column<int>(nullable: false),
                    DateC = table.Column<DateTime>(nullable: false),
                    Diagnostic = table.Column<string>(nullable: true),
                    IdOrdonnance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.UniqueConstraint("AK_Consultations_IdDocteur_IdDossierpatient_DateC", x => new { x.IdDocteur, x.IdDossierpatient, x.DateC });
                    table.ForeignKey(
                        name: "FK_Consultations_Docteurs_IdDocteur",
                        column: x => x.IdDocteur,
                        principalTable: "Docteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consultations_Dossierpatients_IdDossierpatient",
                        column: x => x.IdDossierpatient,
                        principalTable: "Dossierpatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consultations_Ordonnances_IdOrdonnance",
                        column: x => x.IdOrdonnance,
                        principalTable: "Ordonnances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRdv = table.Column<DateTime>(nullable: false),
                    Duree = table.Column<double>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false),
                    IdDocteur = table.Column<int>(nullable: false),
                    IdDossierpatient = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    ThemeColor = table.Column<string>(nullable: true),
                    IsFullDay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.Id);
                    table.UniqueConstraint("AK_RendezVous_DateRdv_IdDocteur_IdDossierpatient", x => new { x.DateRdv, x.IdDocteur, x.IdDossierpatient });
                    table.ForeignKey(
                        name: "FK_RendezVous_Docteurs_IdDocteur",
                        column: x => x.IdDocteur,
                        principalTable: "Docteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendezVous_Dossierpatients_IdDossierpatient",
                        column: x => x.IdDossierpatient,
                        principalTable: "Dossierpatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdDossierpatient",
                table: "Consultations",
                column: "IdDossierpatient");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_IdOrdonnance",
                table: "Consultations",
                column: "IdOrdonnance");

            migrationBuilder.CreateIndex(
                name: "IX_Docteurs_IdSpecialite",
                table: "Docteurs",
                column: "IdSpecialite");

            migrationBuilder.CreateIndex(
                name: "IX_Dossierpatients_IdDocteur",
                table: "Dossierpatients",
                column: "IdDocteur");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_IdCategorie",
                table: "Medicaments",
                column: "IdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Ordonnancechirurgies_IdOrdonnance",
                table: "Ordonnancechirurgies",
                column: "IdOrdonnance");

            migrationBuilder.CreateIndex(
                name: "IX_Ordonnancemedicaments_IdMedicament",
                table: "Ordonnancemedicaments",
                column: "IdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_Ordonnancemedicaments_IdOrdonnance",
                table: "Ordonnancemedicaments",
                column: "IdOrdonnance");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_IdDocteur",
                table: "RendezVous",
                column: "IdDocteur");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_IdDossierpatient",
                table: "RendezVous",
                column: "IdDossierpatient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Ordonnancechirurgies");

            migrationBuilder.DropTable(
                name: "Ordonnancemedicaments");

            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Ordonnances");

            migrationBuilder.DropTable(
                name: "Dossierpatients");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Docteurs");

            migrationBuilder.DropTable(
                name: "Specialites");
        }
    }
}
