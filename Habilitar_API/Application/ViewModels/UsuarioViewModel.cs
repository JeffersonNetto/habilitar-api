namespace Habilitar_API.Application.ViewModels
{
    public class UsuarioViewModel : ViewModelBase
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public int? PessoaId { get; set; }
        public int? UnidadeId { get; set; }
        public bool Profissional { get; set; }
        public bool Fisioterapeuta { get; set; }
        public string Conselho { get; set; }
    }
}
