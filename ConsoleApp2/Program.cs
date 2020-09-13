using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Clinique.Domain.Enums;
using System;
using Microsoft.EntityFrameworkCore.Storage;
using Clinique.EntityFramework.Services;
using Clinique.Domain.Services;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Specialite> dataService = new GenericDataService<Specialite>(new CliniqueDbContextFactory());
            dataService.Create(new Specialite { Titre = "Test Specialite", Description = "EfCore Description" }).Wait();
        }
    }
}
