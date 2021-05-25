using Habilitar.Api.Configuration;
using Habilitar.Api.IoC;
using Habilitar.Core.Helpers;
using Habilitar.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

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
            //services.AddCors();
            //services.AddAutoMapper(typeof(Startup));

            services.Configure<StorageConfig>(Configuration.GetSection(nameof(StorageConfig)))
                .AddSingleton(options => options.GetRequiredService<IOptions<StorageConfig>>().Value);

            services.AddScoped<IAzureBlobStorage, AzureBlobStorage>();            

            services.AddIdentityConfiguration(Configuration);

            services.AddJwtConfiguration(Configuration);
                       
            services.WebApiConfiguration(Configuration);

            //services.AddDbContext<HabilitarDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), _ => _.EnableRetryOnFailure()), ServiceLifetime.Scoped);
            //services.AddDbContext<HabilitarContext>(options => options.UseInMemoryDatabase(databaseName: "Habilitar"), ServiceLifetime.Scoped);            
            
            services.AddFluentEmailConfiguration(Configuration);

            services.Configure<ApiBehaviorOptions>(_ => _.SuppressModelStateInvalidFilter = true);

            services.RegisterServices();

            services.ConfigureApplicationCookie(options => {
                options.Events.OnRedirectToLogin = context => {
                    context.Response.Headers["Location"] = context.RedirectUri;
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddSwaggerConfiguration();
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

            app.UseMvcConfiguration();            
        }
    }
}
