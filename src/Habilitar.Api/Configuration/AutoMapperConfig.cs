using AutoMapper;
using Habilitar.Core.ViewModels;
using Habilitar.Core.Models;

namespace Habilitar.Api.Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {                        
            CreateMap<Unidade, UnidadeViewModelInsert>().ReverseMap();
            CreateMap<Unidade, UnidadeViewModelUpdate>().ReverseMap();            
            CreateMap<Grupo, GrupoViewModel>().ReverseMap();
            CreateMap<Exercicio, ExercicioViewModel>().ReverseMap();
            CreateMap<ExercicioGrupo, ExercicioGrupoViewModel>().ReverseMap();
            CreateMap<CreateUserViewModel, User>().ForMember(nameof(User.PasswordHash), x => x.MapFrom(r => r.Password)).ReverseMap();
        }
    }
}
