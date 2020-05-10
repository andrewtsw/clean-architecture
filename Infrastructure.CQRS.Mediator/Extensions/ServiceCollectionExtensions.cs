using Dump2020.CleanArchitecture.Infrastructure.CQRS.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dump2020.CleanArchitecture.Infrastructure.CQRS.Mediator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            return services;
        }
    }
}
