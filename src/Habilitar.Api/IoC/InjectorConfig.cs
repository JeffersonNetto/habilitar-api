﻿using Habilitar.Api.Extensions;
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
            services.AddScoped<IRepositoryBase<Exercicio>, ExercicioRepository>();            
            services.AddScoped<IRepositoryBase<Grupo>, GrupoRepository>();
            services.AddScoped<IRepositoryBase<Intervalo>, IntervaloRepository>();
            services.AddScoped<IRepositoryBase<LogAcesso>, LogAcessoRepository>();
            services.AddScoped<IRepositoryBase<LogErro>, LogErroRepository>();
            services.AddScoped<IRepositoryBase<Meta>, MetaRepository>();
            services.AddScoped<IRepositoryBase<Metrica>, MetricaRepository>();            
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IRepositoryBase<Unidade>, UnidadeRepository>();                        

            services.AddScoped<IEmpresaService, EmpresaService>();            
            services.AddScoped<IPessoaService, PessoaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddMemoryCache();
        }
    }
}
