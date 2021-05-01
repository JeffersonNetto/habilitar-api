using AutoMapper;
using Habilitar_API.ViewModels;
using Habilitar_API.Models;

namespace Habilitar_API.Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Perfil, PerfilViewModel>().ReverseMap();
            CreateMap<UsuarioPerfil, UsuarioPerfilViewModel>().ReverseMap();
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Unidade, UnidadeViewModel>().ReverseMap();
        }
    }
}
