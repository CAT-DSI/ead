using AutoMapper;
using EAD.AutoMapping;
using EAD.Interfaces.Services;
using EAD.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IServiceCollection" />
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configuring scoped and singleton services
        /// </summary>
        /// <param name="services">Services collection</param>
        public static void Configure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(GetMapperConfiguration().CreateMapper());
            services.AddSingleton<IActiveDirectoryService, ActiveDirectoryService>();
        }

        /// <summary>
        /// Configuring authentification
        /// </summary>
        /// <param name="services">Services collection</param>
        public static void ConfigureAuthentification(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/LogIn";
                    options.Cookie.Name = ".AspNetCore.Authentication";
                });
        }

        /// <summary>
        /// Configuring localization
        /// </summary>
        /// <param name="services">Services collection</param>
        public static void ConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = GlobalConfig.DefaultRequestCulture;
                options.SupportedCultures = GlobalConfig.SupportedCultures;
                options.SupportedUICultures = GlobalConfig.SupportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new CookieRequestCultureProvider()
                    {
                        CookieName = CookieRequestCultureProvider.DefaultCookieName,
                        Options = options
                    }
                };
            });
        }

        /// <summary>
        /// Configuring NLog
        /// </summary>
        /// <param name="services">Services collection</param>
        public static void ConfigureNLog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(logging =>
            {
                logging.AddConfiguration(configuration.GetSection("Logging"));
                logging.AddNLog();
                logging.AddConsole();
            });
        }

        /// <summary>
        /// Configuring routing
        /// </summary>
        /// <param name="services">Services collection</param>
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddMvc()
                .AddSessionStateTempDataProvider()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
        }

        /// <summary>
        /// Configuring session
        /// </summary>
        /// <param name="services">Services collection</param>
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        /// <summary>
        /// Getting <see cref="AutoMapper"/> configuration
        /// </summary>
        private static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(typeof(BarcodeFileProfile));
                mc.AddProfile(typeof(FtpConfigurationProfile));
                mc.AddProfile(typeof(OcrConfigurationProfile));
            });
        }
    }
}
