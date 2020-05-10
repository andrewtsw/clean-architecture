using Dump2020.CleanArchitecture.Interfaces.BackgroundJobService;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dump2020.CleanArchitecture.BackgroundJobService.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBackgroundJobService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(options => options
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("Hangfire")));

            services.AddHangfireServer();

            services.AddScoped<IBackgroundJobService, BackgroundJobService>();

            return services;
        }
    }
}
