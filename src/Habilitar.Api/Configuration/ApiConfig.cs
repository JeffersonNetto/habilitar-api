using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Habilitar.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers().AddNewtonsoftJson(_ =>
            {
                _.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                _.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                _.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            })
            .AddFluentValidation(_ => _.RegisterValidatorsFromAssemblyContaining<Startup>());

            //services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("DefaultConnection"), null, "Banco de dados");            

            //services.AddHealthChecksUI(opt =>
            //{
            //    opt.SetEvaluationTimeInSeconds(60); //time in seconds between check
            //    opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
            //    opt.SetApiMaxActiveRequests(1); //api requests concurrency

            //    opt.AddHealthCheckEndpoint("Habilitar - Healthchecks", "/healthz"); //map health check api
            //})
            //.AddInMemoryStorage();

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseCors(_ => _.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                ////adding endpoint of health check for the health check ui in UI format
                //endpoints.MapHealthChecks("/healthz", new HealthCheckOptions
                //{
                //    Predicate = _ => true,
                //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                //});

                ////map healthcheck ui endpoint - default is /healthchecks-ui/
                //endpoints.MapHealthChecksUI();

                endpoints.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"));
            });

            return app;
        }
    }
}
