﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Habilitar_API.Models
{
    public partial class LogAcesso
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Ip { get; set; }
        public DateTime DataCriacao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}