using AutoMapper;
using Habilitar_API.Application.ViewModels;
using Habilitar_API.Models;

namespace Habilitar_API.Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
