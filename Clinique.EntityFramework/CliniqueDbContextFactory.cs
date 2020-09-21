using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Clinique.EntityFramework
{
    public class CliniqueDbContextFactory : IDesignTimeDbContextFactory<CliniqueDbContext>
    {
        private readonly string _connectionString;

        public CliniqueDbContextFactory()
        {
        }

        public CliniqueDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CliniqueDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>();
            //options.UseSqlServer("Data Source=(localdb)\\MSSQLlocalDB;Integrated Security=True;Database=Clinique;");
            //options.UseSqlServer("Server=.\\SQLExpress;AttachDbFilename=Clinique.mdf;Database=Clinique;Trusted_Connection=Yes;");
            options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Clinic;Integrated Security=True;Pooling=False");
            //options.UseSqlServer(_connectionString);

            return new CliniqueDbContext(options.Options);
        }
    }
}
