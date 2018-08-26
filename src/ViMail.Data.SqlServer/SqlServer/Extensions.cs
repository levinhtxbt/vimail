using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ViMail.Data.SqlServer.SqlServer
{
    public static class Extensions
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EFDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ViMail.Data.SqlServer")));

            return services;
        }
    }
}