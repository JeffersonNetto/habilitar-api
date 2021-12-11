using Habilitar.Api.Extensions;
using Habilitar.Core.Helpers;
using Habilitar.Core.Services;
using Habilitar.Core.Uow;
using Habilitar.Infra.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Habilitar.Api.IoC
{
    public static class InjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<INotificador, Notificador>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddMemoryCache();

            services.Scan(s => s.FromAssemblies(Assembly.Load("Habilitar.Infra"))
                                .AddClasses(c => c.Where(x => !x.IsAbstract && x.IsClass && x.IsPublic).InNamespaces("Habilitar.Infra.Repositories"))
                                .AsMatchingInterface()
                                .WithScopedLifetime()                                
                                .FromAssemblies(Assembly.Load("Habilitar.Core"))
                                .AddClasses(c => c.Where(x => !x.IsAbstract && x.IsClass && x.IsPublic).InNamespaces("Habilitar.Core.Services"))
                                .AsMatchingInterface()
                                .WithScopedLifetime());            
        }
    }
}
