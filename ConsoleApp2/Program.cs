using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Clinique.Domain.Enums;
using System;
using Microsoft.EntityFrameworkCore.Storage;
using Clinique.EntityFramework.Services;
using Clinique.Domain.Services;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Specialite> dataService = new GenericDataService<Specialite>(new CliniqueDbContextFactory());
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

            IDataService<Categorie> dataServiceCategorie = new GenericDataService<Categorie>(new CliniqueDbContextFactory());
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

            IDataService<Medicament> dataServiceMedicament = new GenericDataService<Medicament>(new CliniqueDbContextFactory());
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

            IDataService<Docteur> dataServiceDocteur = new GenericDataService<Docteur>(new CliniqueDbContextFactory());
            dataServiceDocteur.Create(new Docteur { NomM = "Montoya", PrenomM = "Nicole", IdSpecialite = 1, Ville = "Québec", Adresse = "833-4306 Est Av.", Niveau = Niveau.Docteur, NbrPatients = 944 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Miles", PrenomM = "Danielle", IdSpecialite = 2, Ville = "Montréal", Adresse = "P.O. Box 465, 5736 Aenean Av.", Niveau = Niveau.Docteur, NbrPatients = 923 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Shannon", PrenomM = "Blaze", IdSpecialite = 3, Ville = "Mascouche", Adresse = "1731 Cras St.", Niveau = Niveau.Docteur, NbrPatients = 891 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Barrera", PrenomM = "Lareina", IdSpecialite = 4, Ville = "Montréal", Adresse = "517-1700 Sem, Street", Niveau = Niveau.Docteur, NbrPatients = 765 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Anderson", PrenomM = "Sonny", IdSpecialite = 5, Ville = "Trois-Rivière", Adresse = "Ap #340-4959 Quisque Road", Niveau = Niveau.Docteur, NbrPatients = 815 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Wallas", PrenomM = "Cody", IdSpecialite = 6, Ville = "Laval", Adresse = "1914 Sollicitudin St.", Niveau = Niveau.Docteur, NbrPatients = 782 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Stevenson", PrenomM = "Laith", IdSpecialite = 7, Ville = "Montréal", Adresse = "Ap #566-2023 Tincidunt, St.", Niveau = Niveau.Docteur, NbrPatients = 898 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Lang", PrenomM = "Illi", IdSpecialite = 8, Ville = "Rosemère", Adresse = "P.O. Box 631, 9962 Arcu Avenue", Niveau = Niveau.Docteur, NbrPatients = 841 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Coleman", PrenomM = "Julia", IdSpecialite = 9, Ville = "Québec", Adresse = "567-8654 Tellus Av.", Niveau = Niveau.Docteur, NbrPatients = 811 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Nixon", PrenomM = "Porter", IdSpecialite = 10, Ville = "Montréal", Adresse = "Ap #564-9965 Suspendisse Ave", Niveau = Niveau.Docteur, NbrPatients = 903 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Osborn", PrenomM = "Gregory", IdSpecialite = 11, Ville = "Terrebonne", Adresse = "901 Morbi Avenue", Niveau = Niveau.Docteur, NbrPatients = 830 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Bonner", PrenomM = "Kevyn", IdSpecialite = 12, Ville = "Boisbriand", Adresse = "Ap #579-9669 Tempor St.", Niveau = Niveau.Docteur, NbrPatients = 917 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Rivas", PrenomM = "Dahlia", IdSpecialite = 13, Ville = "Sherbrook", Adresse = "9016 Amet, Street", Niveau = Niveau.Docteur, NbrPatients = 983 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Tyson", PrenomM = "Alfonso", IdSpecialite = 14, Ville = "Trois-Rivière", Adresse = "274-8244 Ut Street", Niveau = Niveau.Docteur, NbrPatients = 981 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Walls", PrenomM = "Lionel", IdSpecialite = 15, Ville = "Longueil", Adresse = "Ap #980-6860 At St.", Niveau = Niveau.Docteur, NbrPatients = 799 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Weber", PrenomM = "Orli", IdSpecialite = 16, Ville = "Laval", Adresse = "P.O. Box 117, 1851 Gravida. Avenue", Niveau = Niveau.Docteur, NbrPatients = 751 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Acosta", PrenomM = "Dawn", IdSpecialite = 17, Ville = "Montréal", Adresse = "Ap #948-3723 Sed Avenue", Niveau = Niveau.Docteur, NbrPatients = 898 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Maddox", PrenomM = "Jarrod", IdSpecialite = 5, Ville = "Boisbriand", Adresse = "P.O. Box 109, 8975 Velit. Road", Niveau = Niveau.Docteur, NbrPatients = 781 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Bishop", PrenomM = "Kenyon", IdSpecialite = 1, Ville = "Montréal", Adresse = "P.O. Box 242, 2665 Euismod Ave", Niveau = Niveau.Docteur, NbrPatients = 920 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Petersen", PrenomM = "Hollee", IdSpecialite = 4, Ville = "Longueil", Adresse = "P.O. Box 827, 9094 Interdum. Av.", Niveau = Niveau.Docteur, NbrPatients = 828 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Hays", PrenomM = "Briar", IdSpecialite = 10, Ville = "Mercier", Adresse = "6358 Integer Rd.", Niveau = Niveau.Docteur, NbrPatients = 706 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Meyers", PrenomM = "Fatima", IdSpecialite = 2, Ville = "Québec", Adresse = "5485 Maecenas Road", Niveau = Niveau.Docteur, NbrPatients = 966 }).Wait();

            dataServiceDocteur.Create(new Docteur { NomM = "Suarez", PrenomM = "John", IdSpecialite = 2, Ville = "Montréal", Adresse = "441-3213 Neque. Av.", Niveau = Niveau.Interne, NbrPatients = 27 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Fleming", PrenomM = "Paula", IdSpecialite = 4, Ville = "Québec", Adresse = "P.O. Box 560, 2913 Arcu. Rd.", Niveau = Niveau.Interne, NbrPatients = 28 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Snider", PrenomM = "Hamish", IdSpecialite = 6, Ville = "Sorel", Adresse = "1246 Fringilla Rd.", Niveau = Niveau.Interne, NbrPatients = 72 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Gilmore", PrenomM = "Clarke", IdSpecialite = 10, Ville = "Brossard", Adresse = "143-9989 Aliquam Av.", Niveau = Niveau.Interne, NbrPatients = 92 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Nelson", PrenomM = "Boris", IdSpecialite = 16, Ville = "Longueil", Adresse = "5160 Tellus Rd.", Niveau = Niveau.Interne, NbrPatients = 59 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Hull", PrenomM = "Julian", IdSpecialite = 4, Ville = "Québec", Adresse = "6159 Aliquam St.", Niveau = Niveau.Interne, NbrPatients = 74 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Gaines", PrenomM = "Neville", IdSpecialite = 10, Ville = "Richelieu", Adresse = "264-7657 Ut, Rd.", Niveau = Niveau.Interne, NbrPatients = 33 }).Wait();

            dataServiceDocteur.Create(new Docteur { NomM = "Baldwin", PrenomM = "Peter", IdSpecialite = 1, Ville = "Laval", Adresse = "Ap #401-3520 Class Avenue", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Austin", PrenomM = "Martin", IdSpecialite = 3, Ville = "Sherbrooke", Adresse = "P.O. Box 861, 9017 Duis St.", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Robbins", PrenomM = "Aretha", IdSpecialite = 7, Ville = "Longueil", Adresse = "Ap #914-4993 Nec Street", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Greer", PrenomM = "Calvin", IdSpecialite = 11, Ville = "Montréal", Adresse = "P.O. Box 137, 3671 Ac St.", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Rivers", PrenomM = "Dick", IdSpecialite = 14, Ville = "Trois-Rivière", Adresse = "512-3894 Nisl. St.", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Bean", PrenomM = "Netty", IdSpecialite = 17, Ville = "Sorel", Adresse = "433-4365 Etiam Av.", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Gilliam", PrenomM = "Kylan", IdSpecialite = 2, Ville = "Verdun", Adresse = "681-2911 Eu Av.", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Dillard", PrenomM = "Eaton", IdSpecialite = 10, Ville = "Trois-Rivière", Adresse = "636-1960 Lacus, St.", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Stout", PrenomM = "Tanisha", IdSpecialite = 4, Ville = "Richelieu", Adresse = "P.O. Box 111, 3292 Ut St.", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();
            dataServiceDocteur.Create(new Docteur { NomM = "Richardson", PrenomM = "Dean", IdSpecialite = 5, Ville = "Verdun", Adresse = "840-1897 Nulla St.", Niveau = Niveau.Etudiant, NbrPatients = 0 }).Wait();


        }
    }
}
