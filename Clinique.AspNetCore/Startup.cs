using Clinique.AspNetCore.Controllers;
using Clinique.AspNetCore.State;
using Clinique.Domain.Models;
using Clinique.Domain.Services;
using Clinique.Domain.Services.API;
using Clinique.EntityFramework;
using Clinique.EntityFramework.Services;
using Clinique.Ressources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;

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
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<ICoronavirusCountryService, APICoronavirusCountryService>();
            services.AddSingleton<CoronavirusController>();

            services.AddSingleton<IPasswordHasher<Utilisateur>, PasswordHasher<Utilisateur>>();

            services.AddLocalization(o => o.ResourcesPath = "Ressources" );

            services.AddMvc()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo> {
                    new CultureInfo("en"),
                    new CultureInfo("fr")
                };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("fr");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });

            services.AddRazorPages();
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

            app.UseAuthentication();
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
