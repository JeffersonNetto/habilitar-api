namespace Habilitar_API.ViewModels
{
    public record RegisterViewModel : LoginViewModel
    {
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
