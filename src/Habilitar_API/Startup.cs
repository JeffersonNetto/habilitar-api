using Habilitar.Api.Configuration;
using Habilitar.Infra.Data;
using Habilitar.Api.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

//[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Habilitar.Api
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
            services.WebApiConfig();
            
            services.AddJwtConfiguration(Configuration);
                        
            services.AddDbContext<HabilitarContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), _ => _.EnableRetryOnFailure()), ServiceLifetime.Scoped);
            //services.AddDbContext<HabilitarContext>(options => options.UseInMemoryDatabase(databaseName: "Habilitar"), ServiceLifetime.Scoped);

            services.AddIdentityConfiguration(Configuration);

            services.AddFluentEmailConfiguration(Configuration);
           
            services.RegisterServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Habilitar.Api", Version = "v1" });
            });                        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Habilitar.Api v1"));
            }
            
            app.UseMvcConfig();                        
        }
    }
}
