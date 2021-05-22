using System.Collections.Generic;

namespace Habilitar.Core.ViewModels
{
    public class ExercicioViewModel : ViewModelBaseForUpdate
    {
        public string Nome { get; set; }
        public string NomePopular { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public ICollection<ExercicioGrupoViewModel> ExercicioGrupo { get; set; }        
    }
}
