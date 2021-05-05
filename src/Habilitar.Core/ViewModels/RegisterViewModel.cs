namespace Habilitar.Core.ViewModels
{
    public record RegisterViewModel : LoginViewModel
    {
        public string Email { get; init; }
        public string ConfirmPassword { get; init; }
    }
}
