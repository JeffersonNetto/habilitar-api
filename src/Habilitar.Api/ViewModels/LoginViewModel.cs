namespace Habilitar.Api.ViewModels
{
    public record LoginViewModel
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
