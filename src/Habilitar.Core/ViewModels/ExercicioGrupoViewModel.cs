namespace Habilitar.Core.ViewModels
{
    public class ExercicioGrupoViewModel
    {
        public int ExercicioId { get; set; }
        public int GrupoId { get; set; }                
        public virtual GrupoViewModel Grupo { get; set; }
    }
}
