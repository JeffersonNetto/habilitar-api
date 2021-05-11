using AutoMapper;
using Habilitar.Core.ViewModels;
using Habilitar.Core.Models;

namespace Habilitar.Api.Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {            
            CreateMap<Pessoa, PessoaViewModelInsert>().ReverseMap();
            CreateMap<Pessoa, PessoaViewModelUpdate>().ReverseMap();
            CreateMap<Unidade, UnidadeViewModelInsert>().ReverseMap();
            CreateMap<Unidade, UnidadeViewModelUpdate>().ReverseMap();            
        }
    }
}
