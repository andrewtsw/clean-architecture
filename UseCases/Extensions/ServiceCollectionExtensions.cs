using AutoMapper;
using Dump2020.CleanArchitecture.UseCases.Invoices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dump2020.CleanArchitecture.UseCases.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IInvoicesService, InvoicesService>();

            return services;
        }
    }
}
