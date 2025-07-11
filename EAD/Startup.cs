using EAD.Attributes;
using EAD.Data.Enums;
using EAD.Extensions;
using EAD.Models;
using EAD.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EAD
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
            LoadSettings(configuration);
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, OcrDbContext dbContext)
        {
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
            app.ConfigureErrorPage(env);
            app.ConfigureSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseNLog();
            app.UseAuthorization();
            app.ConfigureLocalization();
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(name: "Default", pattern: "{controller=}/{action=}/{id?}"));

            dbContext.Initialize();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.ConfigureAuthentification();
            services.ConfigureSession();
            services.ConfigureLocalization();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.Configure();
            services.ConfigureRouting();
            services.ConfigureNLog(Configuration);
            services.AddSession();
            services.AddDbContext<OcrDbContext>(options => options.UseSqlServer(Configuration.GetValue<string>("Database:ConnectionString")));
        }

        private static void LoadSettings(IConfiguration configuration)
        {
            GlobalConfig.ApplicationRoles = configuration.GetSection("Permissions").Get<List<ApplicationRole>>();
            GlobalConfig.Countries = Enum.GetValues(typeof(Country)).Cast<Country>().Select(x => (Country: x, CountryCode: x.GetAttribute<CountryCodeAttribute>()));
            GlobalConfig.Domains = configuration.GetSection("Domains").Get<List<Domain>>();
            GlobalConfig.RootDirectory = $"{configuration.GetValue<string>(WebHostDefaults.ContentRootKey)}\\wwwroot";

            foreach (DirectoryType directoryType in Enum.GetValues(typeof(DirectoryType)))
            {
                Directory.CreateDirectory(GlobalConfig.GetDirectory(directoryType));
            }
        }
    }
}