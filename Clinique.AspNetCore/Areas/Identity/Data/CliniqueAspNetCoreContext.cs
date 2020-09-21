using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinique.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinique.AspNetCore.Data
{
    public class CliniqueAspNetCoreContext : IdentityDbContext<CliniqueAspNetCoreUser>
    {
        public DbSet<CliniqueAspNetCoreUser> CliniqueAspNetCoreUsers { get; set; }
        public CliniqueAspNetCoreContext(DbContextOptions<CliniqueAspNetCoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<CliniqueAspNetCoreUser>().Property(o => o.TypeCompte).HasConversion<string>();
        }
    }
}
