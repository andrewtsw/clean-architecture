using Dump2020.CleanArchitecture.Infrastructure.Events.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dump2020.CleanArchitecture.Infrastructure.Events.Mediator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEvents(this IServiceCollection services)
        {
            services.AddScoped<IEventDispatcher, EventDispatcher>();

            return services;
        }
    }
}
