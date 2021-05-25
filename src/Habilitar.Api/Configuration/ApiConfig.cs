using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("DefaultConnection"), null, "Banco de dados");            
            services.AddHealthChecksUI(options => 
            {
                options.SetEvaluationTimeInSeconds(15);               
            })
            .AddInMemoryStorage();            

            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseCors(_ => _.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks("/api/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/ui";                
            });

            return app;
        }
    }
}
