using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailChimp.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMailChimpClient(this IServiceCollection services, string apiKey)
        {
            return services;
        }
    }
}