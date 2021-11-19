using Habilitar.Api.Extensions;
using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Services;
using Habilitar.Core.Uow;
using Habilitar.Infra.Repositories;
using Habilitar.Infra.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Habilitar.Api.IoC
{
    public static class InjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IRepositoryBase<Empresa>, EmpresaRepository>();
            services.AddScoped<IExercicioRepository, ExercicioRepository>();            
            services.AddScoped<IRepositoryBase<Grupo>, GrupoRepository>();
            services.AddScoped<IRepositoryBase<Intervalo>, IntervaloRepository>();            
            services.AddScoped<IRepositoryBase<Meta>, MetaRepository>();
            services.AddScoped<IRepositoryBase<Metrica>, MetricaRepository>();                        
            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IExercicioService, ExercicioService>();
            services.AddScoped<IIntervaloService, IntervaloService>();
            services.AddScoped<IMetricaService, MetricaService>();
            services.AddScoped<IUnidadeService, UnidadeService>();            
            services.AddScoped<IGrupoService, GrupoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMetaService, MetaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddMemoryCache();
        }
    }
}
