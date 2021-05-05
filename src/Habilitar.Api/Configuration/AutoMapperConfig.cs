using AutoMapper;
using Habilitar.Core.ViewModels;
using Habilitar.Core.Models;

namespace Habilitar.Api.Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {            
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Unidade, UnidadeViewModel>().ReverseMap();
        }
    }
}
