using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ViMail.Data.Entities;
using ViMail.Data.MySql.MySql;

namespace ViMail.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IServiceCollection AddCustomizedConfigure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            return services;
        }

        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddMongoDb(Configuration);
            services.AddMySql(configuration);
            //services.AddSqlServer(configuration);
            //services.AddPostgre(configuration);

            return services;
        }

        public static IServiceCollection AddCustomizedIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
                {
                    // Password settings
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 10;

                    // User settings
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<DbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}