using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Clinique.EntityFramework
{
    public class CliniqueDbContextFactory : IDesignTimeDbContextFactory<CliniqueDbContext>
    {
        public CliniqueDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>();
            options.UseSqlServer("Data Source=(localdb)\\MSSQLlocalDB;Integrated Security=True;Database=Clinique;");

            return new CliniqueDbContext(options.Options);
        }
    }
}
