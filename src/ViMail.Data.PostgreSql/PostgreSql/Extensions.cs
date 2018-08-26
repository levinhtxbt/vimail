using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ViMail.Data.PostgreSql.PostgreSql
{
    public static class Extensions
    {
        public static IServiceCollection AddPostgre(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EFDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("ViMail.Data.PostgreSql")));

            return services;
        }
    }
}   