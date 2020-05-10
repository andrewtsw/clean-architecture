using Dump2020.CleanArchitecture.Adapters.DataAccess.SqlServer.Extensions;
using Dump2020.CleanArchitecture.Adapters.ExternalInvoicesService.Extensions;
using Dump2020.CleanArchitecture.BackgroundJobService.Extensions;
using Dump2020.CleanArchitecture.Controllers;
using Dump2020.CleanArchitecture.Domain.Entities;
using Dump2020.CleanArchitecture.Infrastructure.CQRS.Mediator.Extensions;
using Dump2020.CleanArchitecture.UseCases.Extensions;
using Dump2020.CleanArchitecture.UseCases.Invoices;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace Dump2020.CleanArchitecture.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccess(Configuration);
            services.AddUseCases();
            services.AddCQRS();
            services.AddExternalInvoicesService();
            services.AddBackgroundJobService(Configuration);

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Dump2020.CleanArchitecture", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                IncludeSwaggerXmlComments(options, Assembly.GetExecutingAssembly());
                IncludeSwaggerXmlComments(options, typeof(InvoicesController).Assembly);
                IncludeSwaggerXmlComments(options, typeof(IInvoicesService).Assembly);
                IncludeSwaggerXmlComments(options, typeof(Invoice).Assembly);
            });
        }

        private static void IncludeSwaggerXmlComments(SwaggerGenOptions options, Assembly assembly)
        {
            var xmlFile = $"{assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseHangfireDashboard();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dump2020.CleanArchitecture - V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
