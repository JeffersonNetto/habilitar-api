using FluentValidation.AspNetCore;
using Habilitar_API.Data;
using Habilitar_API.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Net.Mail;
using System.Text;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Habilitar_API
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
            services.AddCors();            

            var key = Encoding.ASCII.GetBytes(Configuration["Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = System.TimeSpan.Zero
                };
            });

            services.AddControllers().AddNewtonsoftJson(_ =>
            {
                _.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                _.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                _.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            })
            .AddFluentValidation(_ => _.RegisterValidatorsFromAssemblyContaining<Startup>());
            
            services.AddDbContext<HabilitarContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), _ => _.EnableRetryOnFailure()), ServiceLifetime.Scoped);

            //services.AddDbContext<HabilitarContext>(options => options.UseInMemoryDatabase(databaseName: "Habilitar"), ServiceLifetime.Scoped);

            services
                .AddFluentEmail(Configuration["Email:Address"] ?? "habilitar@outlook.com.br")
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient("smtp.live.com", 587)
                {
                    Credentials = new NetworkCredential(Configuration["Email:Address"] ?? "habilitar@outlook.com.br", Configuration["Email:Password"] ?? "123456"),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                });
            
            services.Configure<ApiBehaviorOptions>(_ => _.SuppressModelStateInvalidFilter = true);

            services.RegisterServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Habilitar_API", Version = "v1" });
            });                        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Habilitar_API v1"));
            }

            app.UseCors(_ => _.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
