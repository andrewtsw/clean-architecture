using Dump2020.CleanArchitecture.Interfaces.ExternalInvoicesService;
using Microsoft.Extensions.DependencyInjection;

namespace Dump2020.CleanArchitecture.Adapters.ExternalInvoicesService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExternalInvoicesService(this IServiceCollection services)
        {
            services.AddScoped<IExternalInvoicesService, ExternalInvoicesService>();

            return services;
        }
    }
}
