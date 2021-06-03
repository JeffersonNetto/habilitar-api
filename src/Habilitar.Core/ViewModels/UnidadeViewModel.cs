namespace Habilitar.Core.ViewModels
{
    public record UnidadeViewModelInsert : ViewModelBaseForInsert
    {
        public string Nome { get; init; }
        public string Email { get; init; }
        public string Telefone { get; init; }
        public string Cnes { get; init; }
        public string Latitude { get; init; }
        public string Longitude { get; init; }
        public int EmpresaId { get; init; }
    }

    public record UnidadeViewModelUpdate : ViewModelBaseForUpdate
    {
        public string Nome { get; init; }
        public string Email { get; init; }
        public string Telefone { get; init; }
        public string Cnes { get; init; }
        public string Latitude { get; init; }
        public string Longitude { get; init; }
        public int EmpresaId { get; init; }
    }
}
