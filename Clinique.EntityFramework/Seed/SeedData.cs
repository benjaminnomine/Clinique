using Clinique.Domain.Enums;
using Clinique.Domain.Models;
using Clinique.Domain.Services;
using Clinique.EntityFramework.Services;
using System;

namespace Clinique.EntityFramework.Seed
{

    public class SeedData
    {
        public readonly CliniqueDbContextFactory _contextFactory = new CliniqueDbContextFactory();

        public SeedData(CliniqueDbContextFactory dbContextFactory)
        {
            _contextFactory = dbContextFactory;
        }
        public static void InsertData()
        {
            using CliniqueDbContext context = new CliniqueDbContextFactory().CreateDbContext();

            CliniqueDbContextFactory cliniqueDbContextFactory = new CliniqueDbContextFactory("Data Source=(localdb)\\MSSQLlocalDB;Integrated Security=True;Database=Clinique;");
            if (context.Specialites.FindAsync(1) == null)
            {
                IDataService<Specialite> dataService = new GenericDataService<Specialite>(cliniqueDbContextFactory);
                dataService.Create(new Specialite { Titre = "Cardiologie", Description = "Traite les troubles du cœur" }).Wait();
                dataService.Create(new Specialite { Titre = "Dermatologie", Description = "Traite la peau, les muqueuses et les phanères" }).Wait();
                dataService.Create(new Specialite { Titre = "Gastroentérologie", Description = "Traite le système digestif et ses maladies" }).Wait();
                dataService.Create(new Specialite { Titre = "Gériatrie", Description = "Traite les personnes agées" }).Wait();
                dataService.Create(new Specialite { Titre = "Hématologie", Description = "Traite le sang et ses maladies" }).Wait();
                dataService.Create(new Specialite { Titre = "Neurochirurgie", Description = "Chirurgie du système nerveux" }).Wait();
                dataService.Create(new Specialite { Titre = "Ophtalmologie", Description = "Traite les maladies de l'œil et de ses annexes" }).Wait();
                dataService.Create(new Specialite { Titre = "Pédiatrie", Description = "Traite le développement physiologique de l'enfant" }).Wait();
                dataService.Create(new Specialite { Titre = "Pneumologie", Description = "Traite les pathologies respiratoires" }).Wait();
                dataService.Create(new Specialite { Titre = "Rhumatologie", Description = "Traite les maladies de l'appareil locomoteur" }).Wait();
                dataService.Create(new Specialite { Titre = "Stomatologie", Description = "Traite les troubles bucaux dentaires" }).Wait();
                dataService.Create(new Specialite { Titre = "Orthopédie", Description = "Traite les troubles du squelette, des muscles et des tendons" }).Wait();
                dataService.Create(new Specialite { Titre = "Gynécologie", Description = "Traite les troubles liés aux organes génitaux" }).Wait();
                dataService.Create(new Specialite { Titre = "Urologie", Description = "Traite les troubles de l'appareil urinaire" }).Wait();
                dataService.Create(new Specialite { Titre = "Obstétrie", Description = "Traite les troubles liés à la grossesse et à l'accouchement" }).Wait();
                dataService.Create(new Specialite { Titre = "Traumatologie", Description = "Traite les blessures et les suites d'accidents" }).Wait();
                dataService.Create(new Specialite { Titre = "Otorhinolaryngologie", Description = "Traite les troubles liés aux maladies de l'oreille, du nez et de la gorge" }).Wait();
            }
            if (context.Categories.FindAsync(1) == null)
            {
                IDataService<Categorie> dataServiceCategorie = new GenericDataService<Categorie>(cliniqueDbContextFactory);
                dataServiceCategorie.Create(new Categorie { Nom = "Antispasmodique", Description = "Lutte contre les spasmes musculaires" }).Wait();
                dataServiceCategorie.Create(new Categorie { Nom = "Analgésiques", Description = "Diminue ou supprime la sensibilité à la douleur" }).Wait();
                dataServiceCategorie.Create(new Categorie { Nom = "Antibiotiques", Description = "Détruit ou bloque la croissance des bactéries" }).Wait();
                dataServiceCategorie.Create(new Categorie { Nom = "Anxiolytique", Description = "Lutte contre l'anxiété" }).Wait();
                dataServiceCategorie.Create(new Categorie { Nom = "Mucolytique", Description = "Fluidifie le mucus" }).Wait();
                dataServiceCategorie.Create(new Categorie { Nom = "Eugéroïques", Description = "Améliore l'éveil et la vigilence" }).Wait();
                dataServiceCategorie.Create(new Categorie { Nom = "Myorelaxant", Description = "Pour décontracter les muscles" }).Wait();
                dataServiceCategorie.Create(new Categorie { Nom = "Intercalation ", Description = "Qualifie l'inclusion réversible d'une molécule" }).Wait();
                dataServiceCategorie.Create(new Categorie { Nom = "Neuroleptiques ", Description = "Effet tranquillisant majeur, anti-délirant" }).Wait();
                dataServiceCategorie.Create(new Categorie { Nom = "Diurétique ", Description = "Inhibe la réabsorption rénale des ions sodium" }).Wait();
            }
            if (context.Medicaments.FindAsync(1) == null)
            {
                IDataService<Medicament> dataServiceMedicament = new GenericDataService<Medicament>(cliniqueDbContextFactory);
                dataServiceMedicament.Create(new Medicament { NomMed = "Phloroglucinol", Prix = 11.95, IdCategorie = 1 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Trimébutine", Prix = 13.95, IdCategorie = 1 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Mébévérine", Prix = 12.95, IdCategorie = 1 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Ibuprofène", Prix = 8.95, IdCategorie = 2 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Morphine", Prix = 30.95, IdCategorie = 2 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Codéine", Prix = 20.95, IdCategorie = 2 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Indométacine", Prix = 18.95, IdCategorie = 2 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Pénicilline", Prix = 17.95, IdCategorie = 3 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Tétracycline", Prix = 12.95, IdCategorie = 3 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Alprazolam", Prix = 21.95, IdCategorie = 4 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Bromazépam", Prix = 19.95, IdCategorie = 4 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Oxazépam", Prix = 18.95, IdCategorie = 4 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Triazolam", Prix = 19.95, IdCategorie = 4 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Carbocystéine", Prix = 7.95, IdCategorie = 5 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Acétylcystéine", Prix = 8.95, IdCategorie = 5 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "modafinil", Prix = 11.95, IdCategorie = 6 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "adrafinil", Prix = 14.95, IdCategorie = 6 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Méphénésine", Prix = 11.95, IdCategorie = 7 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Thiocolchicoside", Prix = 14.95, IdCategorie = 7 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Mitoxantrone", Prix = 42.95, IdCategorie = 8 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Benzopyrène", Prix = 38.95, IdCategorie = 8 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Chlorpromazine", Prix = 39.95, IdCategorie = 9 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Cyamémazine", Prix = 41.95, IdCategorie = 9 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Trifluopérazine", Prix = 43.95, IdCategorie = 9 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Théobromine", Prix = 5.45, IdCategorie = 10 }).Wait();
                dataServiceMedicament.Create(new Medicament { NomMed = "Théophylline", Prix = 5.95, IdCategorie = 10 }).Wait();
            }
            if (context.Docteurs.FindAsync(1) == null)
            {
                IDataService<Docteur> dataServiceDocteur = new GenericDataService<Docteur>(cliniqueDbContextFactory);
                dataServiceDocteur.Create(new Docteur { NomM = "Montoya", PrenomM = "Nicole", IdSpecialite = 1, Ville = "Québec", Adresse = "833-4306 Est Av.", Niveau = Niveau.Docteur, NbrPatients = 40 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Miles", PrenomM = "Danielle", IdSpecialite = 2, Ville = "Montréal", Adresse = "P.O. Box 465, 5736 Aenean Av.", Niveau = Niveau.Docteur, NbrPatients = 50 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Shannon", PrenomM = "Blaze", IdSpecialite = 3, Ville = "Mascouche", Adresse = "1731 Cras St.", Niveau = Niveau.Docteur, NbrPatients = 43 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Barrera", PrenomM = "Lareina", IdSpecialite = 4, Ville = "Montréal", Adresse = "517-1700 Sem, Street", Niveau = Niveau.Interne, NbrPatients = 44 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Anderson", PrenomM = "Sonny", IdSpecialite = 5, Ville = "Trois-Rivière", Adresse = "Ap #340-4959 Quisque Road", Niveau = Niveau.Interne, NbrPatients = 65 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Wallas", PrenomM = "Cody", IdSpecialite = 6, Ville = "Laval", Adresse = "1914 Sollicitudin St.", Niveau = Niveau.Interne, NbrPatients = 68 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Stevenson", PrenomM = "Laith", IdSpecialite = 7, Ville = "Montréal", Adresse = "Ap #566-2023 Tincidunt, St.", Niveau = Niveau.Interne, NbrPatients = 89 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Lang", PrenomM = "Illi", IdSpecialite = 8, Ville = "Rosemère", Adresse = "P.O. Box 631, 9962 Arcu Avenue", Niveau = Niveau.Interne, NbrPatients = 23 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Coleman", PrenomM = "Julia", IdSpecialite = 9, Ville = "Québec", Adresse = "567-8654 Tellus Av.", Niveau = Niveau.Etudiant, NbrPatients = 42 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Nixon", PrenomM = "Porter", IdSpecialite = 10, Ville = "Montréal", Adresse = "Ap #564-9965 Suspendisse Ave", Niveau = Niveau.Etudiant, NbrPatients = 44 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Osborn", PrenomM = "Gregory", IdSpecialite = 11, Ville = "Terrebonne", Adresse = "901 Morbi Avenue", Niveau = Niveau.Etudiant, NbrPatients = 32 }).Wait();
                dataServiceDocteur.Create(new Docteur { NomM = "Bonner", PrenomM = "Kevyn", IdSpecialite = 12, Ville = "Boisbriand", Adresse = "Ap #579-9669 Tempor St.", Niveau = Niveau.Etudiant, NbrPatients = 18 }).Wait();
            }
            if(context.Dossierpatients.Find(1) == null)
            {
                IDataService<Dossierpatient> dataServicePatient = new GenericDataService<Dossierpatient>(cliniqueDbContextFactory);
                dataServicePatient.Create(new Dossierpatient { NomP = "Gary", PrenomP = "Cody", Genre = Genre.M, NumAS = int.Parse("087697207"), DateNaiss = DateTime.ParseExact("17-10-1969", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 1 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Signe", PrenomP = "Arsenio", Genre = Genre.M, NumAS = int.Parse("570805416"), DateNaiss = DateTime.ParseExact("12-07-1954", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 1 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Ethan", PrenomP = "Benjamin", Genre = Genre.M, NumAS = int.Parse("694289513"), DateNaiss = DateTime.ParseExact("30-09-1981", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 1 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Reece", PrenomP = "Raven", Genre = Genre.M, NumAS = int.Parse("234266773"), DateNaiss = DateTime.ParseExact("16-03-1971", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 1 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Stone", PrenomP = "Armando", Genre = Genre.M, NumAS = int.Parse("308396621"), DateNaiss = DateTime.ParseExact("11-03-1994", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 1 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Brennan", PrenomP = "Ulric", Genre = Genre.M, NumAS = int.Parse("671860211"), DateNaiss = DateTime.ParseExact("19-01-1963", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 2 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Nasim", PrenomP = "Hasad", Genre = Genre.M, NumAS = int.Parse("682730718"), DateNaiss = DateTime.ParseExact("10-01-1996", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 2 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Jonah", PrenomP = "Melanie", Genre = Genre.F, NumAS = int.Parse("065359150"), DateNaiss = DateTime.ParseExact("03-07-1986", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 2 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "MacKensie", PrenomP = "Blaine", Genre = Genre.M, NumAS = int.Parse("955847595"), DateNaiss = DateTime.ParseExact("26-08-1985", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 2 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Anthony", PrenomP = "Wendy", Genre = Genre.F, NumAS = int.Parse("559170279"), DateNaiss = DateTime.ParseExact("24-04-1959", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 2 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Malcolm", PrenomP = "Abigail", Genre = Genre.F, NumAS = int.Parse("762671287"), DateNaiss = DateTime.ParseExact("31-12-1956", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 2 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Ayanna", PrenomP = "Chaney", Genre = Genre.F, NumAS = int.Parse("328998463"), DateNaiss = DateTime.ParseExact("30-04-1952", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 3 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Lawrence", PrenomP = "Shana", Genre = Genre.F, NumAS = int.Parse("652369687"), DateNaiss = DateTime.ParseExact("24-11-1985", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 3 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Reese", PrenomP = "Brody", Genre = Genre.M, NumAS = int.Parse("563560697"), DateNaiss = DateTime.ParseExact("16-03-1945", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 3 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Ariel", PrenomP = "Kitra", Genre = Genre.F, NumAS = int.Parse("675193304"), DateNaiss = DateTime.ParseExact("24-07-1984", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 3 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Vera", PrenomP = "Destiny", Genre = Genre.F, NumAS = int.Parse("846976819"), DateNaiss = DateTime.ParseExact("28-09-1960", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 3 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Solomon", PrenomP = "Desiree", Genre = Genre.F, NumAS = int.Parse("047025465"), DateNaiss = DateTime.ParseExact("10-12-1953", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 4 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Alyssa", PrenomP = "Zahir", Genre = Genre.M, NumAS = int.Parse("100650571"), DateNaiss = DateTime.ParseExact("10-08-1997", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 4 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Michelle", PrenomP = "Deirdre", Genre = Genre.M, NumAS = int.Parse("518825195"), DateNaiss = DateTime.ParseExact("23-10-1966", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 4 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Pamela", PrenomP = "Victor", Genre = Genre.M, NumAS = int.Parse("350477766"), DateNaiss = DateTime.ParseExact("19-10-1947", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 4 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Basil", PrenomP = "Ivana", Genre = Genre.F, NumAS = int.Parse("340315266"), DateNaiss = DateTime.ParseExact("19-04-1984", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 5 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Kylynn", PrenomP = "Karyn", Genre = Genre.F, NumAS = int.Parse("021466875"), DateNaiss = DateTime.ParseExact("17-10-1967", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 5 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Marshall", PrenomP = "Cruz", Genre = Genre.M, NumAS = int.Parse("067077719"), DateNaiss = DateTime.ParseExact("21-12-1965", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 5 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Hoyt", PrenomP = "Lois", Genre = Genre.M, NumAS = int.Parse("171920440"), DateNaiss = DateTime.ParseExact("07-03-1950", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 6 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Baker", PrenomP = "Oren", Genre = Genre.M, NumAS = int.Parse("800161903"), DateNaiss = DateTime.ParseExact("21-05-1977", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 6 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Fitzgerald", PrenomP = "Melinda", Genre = Genre.F, NumAS = int.Parse("812681112"), DateNaiss = DateTime.ParseExact("02-08-1977", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 7 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Emery", PrenomP = "Riley", Genre = Genre.M, NumAS = int.Parse("185787009"), DateNaiss = DateTime.ParseExact("12-10-1951", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 7 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Upton", PrenomP = "Illana", Genre = Genre.F, NumAS = int.Parse("169015260"), DateNaiss = DateTime.ParseExact("05-01-1998", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 8 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Andrew", PrenomP = "Elvis", Genre = Genre.M, NumAS = int.Parse("269990792"), DateNaiss = DateTime.ParseExact("14-08-1963", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 8 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Chaney", PrenomP = "Roanna", Genre = Genre.F, NumAS = int.Parse("957094519"), DateNaiss = DateTime.ParseExact("18-08-1948", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 8 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Dale", PrenomP = "Sage", Genre = Genre.M, NumAS = int.Parse("154029565"), DateNaiss = DateTime.ParseExact("09-11-1959", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 9 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Brynne", PrenomP = "Dustin", Genre = Genre.M, NumAS = int.Parse("972671903"), DateNaiss = DateTime.ParseExact("28-01-1972", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 10 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Glenna", PrenomP = "Quamar", Genre = Genre.M, NumAS = int.Parse("852253400"), DateNaiss = DateTime.ParseExact("16-04-1956", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 10 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Tanek", PrenomP = "Orson", Genre = Genre.M, NumAS = int.Parse("669886731"), DateNaiss = DateTime.ParseExact("19-11-1983", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 10 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Pearl", PrenomP = "Garrison", Genre = Genre.M, NumAS = int.Parse("001515089"), DateNaiss = DateTime.ParseExact("15-11-1997", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 11 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Damon", PrenomP = "Evelyn", Genre = Genre.F, NumAS = int.Parse("324634997"), DateNaiss = DateTime.ParseExact("21-09-1949", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 11 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Calista", PrenomP = "Griffith", Genre = Genre.M, NumAS = int.Parse("287947469"), DateNaiss = DateTime.ParseExact("28-01-1981", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 11 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Raya", PrenomP = "Paula", Genre = Genre.F, NumAS = int.Parse("872969746"), DateNaiss = DateTime.ParseExact("16-02-1946", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 11 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Melodie", PrenomP = "Oliver", Genre = Genre.M, NumAS = int.Parse("248439549"), DateNaiss = DateTime.ParseExact("04-08-1946", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 12 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Price", PrenomP = "Finn", Genre = Genre.M, NumAS = int.Parse("673358131"), DateNaiss = DateTime.ParseExact("23-11-1945", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 12 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Zelda", PrenomP = "Aristotle", Genre = Genre.M, NumAS = int.Parse("718610868"), DateNaiss = DateTime.ParseExact("19-11-1978", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 12 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Abbot", PrenomP = "Carter", Genre = Genre.M, NumAS = int.Parse("903902252"), DateNaiss = DateTime.ParseExact("20-06-1966", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 12 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Clinton", PrenomP = "Stuart", Genre = Genre.M, NumAS = int.Parse("946838471"), DateNaiss = DateTime.ParseExact("10-01-1991", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 4 }).Wait();
                dataServicePatient.Create(new Dossierpatient { NomP = "Conan", PrenomP = "Christopher", Genre = Genre.M, NumAS = int.Parse("542636154"), DateNaiss = DateTime.ParseExact("27-10-1967", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture), DateC = DateTime.Now, IdDocteur = 7 }).Wait();
            }





        }
    }
}
