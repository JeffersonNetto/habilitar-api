using Habilitar.Api.Configuration;
using Habilitar.Api.IoC;
using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Services;
using Habilitar.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
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

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.Headers["Location"] = context.RedirectUri;
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddSwaggerConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context, IUsuarioService usuarioService)
        {
            //if (env.IsDevelopment())
            //{
            context.Database.EnsureCreated();            

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Habilitar.Api v1"));
            //}

            app.UseMvcConfiguration();

            var id = Guid.Parse("bdd68454-64a2-4d58-deda-08d9b02f09e5");

            var usuarioExiste = usuarioService.UsuarioExiste(id).Result;

            if(!usuarioExiste)
            {
                usuarioService.Adicionar(new User
                {
                    Nome = "Admin",
                    Email = "admin@habilitar.com",
                    UserName = "Admin",
                    Sobrenome = "Admin",
                    NormalizedEmail = "ADMIN@HABILITAR.COM",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "123456",
                    SecurityStamp = "BSO7L35KRNRKTIVDS7T4VVFS7OQVP6MN",
                    PhoneNumber = "31999999999",
                    DataCriacao = DateTime.Now,
                    UsuarioCriacaoId = id,
                    Id = id,
                    Ativo = true,
                    Ip = "localhost",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    Sexo = "M",
                    Cpf = "08358330626",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "c6d465f1-5575-4dce-95a3-999a270c0cad",
                    DataNascimento = DateTime.Now,
                }, "Admin").Wait();
            }
        }
    }
}
