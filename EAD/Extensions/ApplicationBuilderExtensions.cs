using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Collections.Generic;

namespace EAD.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="IApplicationBuilder" />
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configuring error page
        /// </summary>
        /// <param name="app">Object of type <see cref="IApplicationBuilder"/> </param>
        /// <param name="env">Object if type <see cref="IWebHostEnvironment"/></param>
        public static void ConfigureErrorPage(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
        }

        /// <summary>
        /// Configuring localization
        /// </summary>
        /// <param name="app">Object of type <see cref="IApplicationBuilder"/></param>
        public static void ConfigureLocalization(this IApplicationBuilder app)
        {
            app.UseRequestLocalization();
            app.UseCookiePolicy();
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = GlobalConfig.DefaultRequestCulture,
                SupportedCultures = GlobalConfig.SupportedCultures,
                SupportedUICultures = GlobalConfig.SupportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new CookieRequestCultureProvider()
                    {
                        CookieName = CookieRequestCultureProvider.DefaultCookieName
                    }
                }
            });
        }

        /// <summary>
        /// Configuring session
        /// </summary>
        /// <param name="app">Object of type <see cref="IApplicationBuilder"/></param>
        public static void ConfigureSession(this IApplicationBuilder app)
        {
            app.UseSession(new SessionOptions()
            {
                Cookie = new CookieBuilder()
                {
                    Name = Guid.NewGuid().ToString()
                },
                IdleTimeout = TimeSpan.FromHours(8)
            });
        }

        /// <summary>
        /// Configuring NLog
        /// </summary>
        /// <param name="app">Object of type <see cref="IApplicationBuilder"/></param>
        public static void UseNLog(this IApplicationBuilder app)
        {
            app.Use(async (ctxt, next) =>
            {
                if (ctxt.User == null)
                {
                    await next();
                }
                else
                {
                    using (ScopeContext.PushProperty("UserSid", ctxt.User.Identity.Name))
                    {
                        await next();
                    }
                }
            });
        }
    }
}
