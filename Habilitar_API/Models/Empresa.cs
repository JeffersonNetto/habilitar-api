﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Habilitar_API.Models
{
    public partial class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Ip { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioCriacaoId { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int? UsuarioAtualizacaoId { get; set; }
    }
}