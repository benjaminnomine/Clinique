using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinique.Domain.Models;
using Clinique.Domain.Services;
using Clinique.EntityFramework;
using Clinique.EntityFramework.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Clinique.AspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();

            string connexionString = Configuration.GetConnectionString("default");

            services.AddDbContext<CliniqueDbContext>(o => o.UseSqlServer(connexionString));
            services.AddSingleton<CliniqueDbContextFactory>(new CliniqueDbContextFactory(connexionString));
            services.AddSingleton<IAuthentificationService, AuthentificationService>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IDataService<Utilisateur>, AccountService>();
            services.AddSingleton<IDataService<Consultation>, ConsultationDataService>();




            services.AddSingleton<IPasswordHasher<Utilisateur>, PasswordHasher<Utilisateur>>();


            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
