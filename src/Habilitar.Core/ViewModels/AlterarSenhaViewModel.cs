namespace Habilitar.Core.ViewModels
{
    public record AlterarSenhaViewModel
    {
        public string SenhaAtual { get; init; }
        public string NovaSenha { get; init; }
        public string ConfirmarSenha { get; init; }
    }
}
