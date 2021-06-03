using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Habilitar.Core.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            PacienteMeta = new HashSet<PacienteMeta>();
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cpf { get; set; }
        public string IntegracaoId { get; set; }
        public string Ip { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public Guid UsuarioCriacaoId { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public Guid? UsuarioAtualizacaoId { get; set; }
        [NotMapped]
        public string Role { get; set; }
        public virtual ICollection<PacienteMeta> PacienteMeta { get; set; }
    }
}
