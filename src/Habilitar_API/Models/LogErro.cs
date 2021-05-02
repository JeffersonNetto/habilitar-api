﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Habilitar_API.Models
{
    [Index(nameof(UsuarioId), Name = "IX_LogErro_UsuarioId")]
    public partial class LogErro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(2000)]
        public string Erro { get; set; }
        [Required]
        [StringLength(100)]
        public string Acao { get; set; }
        [Required]
        [StringLength(100)]
        public string Tela { get; set; }
        public int? UsuarioId { get; set; }
        [Required]
        [StringLength(20)]
        public string Ip { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        [InverseProperty("LogErro")]
        public virtual Usuario Usuario { get; set; }
    }
}