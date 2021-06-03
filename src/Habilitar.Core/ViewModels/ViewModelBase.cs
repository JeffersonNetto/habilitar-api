using System;

namespace Habilitar.Core.ViewModels
{
    public abstract record ViewModelBaseForInsert
    {        
        public string Ip { get; init; }
        public bool Ativo { get; init; } = true;
        public DateTime DataCriacao { get; init; } = DateTime.Now;
        public Guid UsuarioCriacaoId { get; set; }     
    }

    public abstract record ViewModelBaseForUpdate : ViewModelBaseForInsert
    {
        public int Id { get; init; }        
        public DateTime? DataAtualizacao { get; init; }
        public Guid? UsuarioAtualizacaoId { get; init; }
    }
}
