namespace Habilitar.Core.ViewModels
{
    public class UnidadeViewModelInsert : ViewModelBaseForInsert
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnes { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int EmpresaId { get; set; }
    }

    public class UnidadeViewModelUpdate : ViewModelBaseForUpdate
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnes { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int EmpresaId { get; set; }
    }
}
