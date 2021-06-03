namespace Habilitar.Core.ViewModels
{
    public record GrupoViewModel : ViewModelBaseForUpdate
    {        
        public string Descricao { get; init; }
        public string Observacao { get; init; }
    }
}
