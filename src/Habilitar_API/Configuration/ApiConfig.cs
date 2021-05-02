using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Habilitar_API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddCors();
            services.Configure<ApiBehaviorOptions>(_ => _.SuppressModelStateInvalidFilter = true);

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers().AddNewtonsoftJson(_ =>
            {
                _.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                _.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                _.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            })
            .AddFluentValidation(_ => _.RegisterValidatorsFromAssemblyContaining<Startup>());

            return services;
        }

        public static IApplicationBuilder UseMvcConfig(this IApplicationBuilder app)
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

            return app;
        }
    }
}
