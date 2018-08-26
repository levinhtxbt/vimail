using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using ViMail.Data;
using ViMail.Web.Extensions;

namespace ViMail.Web
{
    public class DbContextFactory : IDesignTimeDbContextFactory<EFDbContext>
    {
        public EFDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var contentRootPath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(contentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", true);

            builder.AddEnvironmentVariables();
            var configuration = builder.Build();
            
            var containerBuilder = new ContainerBuilder();
            IServiceCollection services = new ServiceCollection();

            services.AddCustomizedDataStore(configuration);

            containerBuilder.Populate(services);
            var serviceProvider = containerBuilder.Build().Resolve<IServiceProvider>();

            return serviceProvider.GetRequiredService<EFDbContext>();
        }
    }
}