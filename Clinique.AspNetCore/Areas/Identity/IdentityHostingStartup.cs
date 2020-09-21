using System;
using Clinique.AspNetCore.Data;
using Clinique.Domain.Models;
using Clinique.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Clinique.AspNetCore.Areas.Identity.IdentityHostingStartup))]
namespace Clinique.AspNetCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CliniqueDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("default")));

                services.AddDefaultIdentity<CliniqueAspNetCoreUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CliniqueDbContext>();
            });
        }
    }
}