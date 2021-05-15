﻿using System;

namespace Habilitar.Core.ViewModels
{
    public abstract class ViewModelBaseForInsert
    {        
        public string Ip { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public Guid UsuarioCriacaoId { get; set; }     
    }

    public abstract class ViewModelBaseForUpdate : ViewModelBaseForInsert
    {
        public int Id { get; set; }        
        public DateTime? DataAtualizacao { get; set; }
        public Guid? UsuarioAtualizacaoId { get; set; }
    }
}
