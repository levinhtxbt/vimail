using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace ViMail.Data.MySql.MySql
{
    public static class Extensions
    {
        public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EFDbContext>(options =>
                           options.UseMySql(connectionString, mySqlOptions =>
                           {
                               mySqlOptions.MigrationsAssembly("ViMail.Data.MySql");
                               mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); 
                           }));

            return services;
        }
    }
}