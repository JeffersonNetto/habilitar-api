using Habilitar_API.Models;
using Habilitar_API.Repositories;
using Habilitar_API.Services;
using Habilitar_API.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace Habilitar_API.IoC
{
    public static class InjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IRepositoryBase<Empresa>, EmpresaRepository>();
            services.AddScoped<IRepositoryBase<Exercicio>, ExercicioRepository>();
            services.AddScoped<IRepositoryBase<Funcao>, FuncaoRepository>();
            services.AddScoped<IRepositoryBase<Grupo>, GrupoRepository>();
            services.AddScoped<IRepositoryBase<Intervalo>, IntervaloRepository>();
            services.AddScoped<IRepositoryBase<LogAcesso>, LogAcessoRepository>();
            services.AddScoped<IRepositoryBase<LogErro>, LogErroRepository>();
            services.AddScoped<IRepositoryBase<Meta>, MetaRepository>();
            services.AddScoped<IRepositoryBase<Metrica>, MetricaRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IRepositoryBase<Pessoa>, PessoaRepository>();
            services.AddScoped<IRepositoryBase<Unidade>, UnidadeRepository>();            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IEmpresaService, EmpresaService>();

            services.AddMemoryCache();
        }
    }
}
