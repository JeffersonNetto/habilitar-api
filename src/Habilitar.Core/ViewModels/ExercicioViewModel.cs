using System.Collections.Generic;

namespace Habilitar.Core.ViewModels
{
    public record ExercicioViewModel : ViewModelBaseForUpdate
    {
        public string Nome { get; init; }
        public string NomePopular { get; init; }
        public string Descricao { get; init; }
        public string Url { get; init; }
        public ICollection<ExercicioGrupoViewModel> ExercicioGrupo { get; init; }        
    }
}
