using Habilitar_API.Models;
using Habilitar_API.Repositories;
using Habilitar_API.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace Habilitar_API.IoC
{
    public static class InjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepositoryBase<Empresa>, EmpresaRepository>();
            services.AddScoped<IRepositoryBase<Unidade>, UnidadeRepository>();
            services.AddScoped<IRepositoryBase<Exercicio>, ExercicioRepository>();
            services.AddMemoryCache();
        }
    }
}
