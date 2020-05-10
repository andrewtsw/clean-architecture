using Dump2020.CleanArchitecture.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dump2020.CleanArchitecture.Adapters.DataAccess.SqlServer.Extensions
{
    /// <summary>
    /// Contains service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add persistence layer services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">Configuration.</param>
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<AppDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("Dump2020_CleanArchitecture")))
                .AddScoped<IDbContext>(provider => provider
                    .GetService<AppDbContext>());

            QueryableExtensions.QueryableAdapter = new EfCoreQueryableAdapter();

            return services;
        }
    }
}
