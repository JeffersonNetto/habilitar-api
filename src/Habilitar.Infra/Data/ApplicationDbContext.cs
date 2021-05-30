using Habilitar.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Habilitar.Infra.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Exercicio> Exercicio { get; set; }
        public virtual DbSet<ExercicioGrupo> ExercicioGrupo { get; set; }
        public virtual DbSet<ExercicioMetrica> ExercicioMetrica { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Intervalo> Intervalo { get; set; }
        public virtual DbSet<LogAcesso> LogAcesso { get; set; }
        public virtual DbSet<LogErro> LogErro { get; set; }
        public virtual DbSet<Meta> Meta { get; set; }
        public virtual DbSet<Metrica> Metrica { get; set; }
        public virtual DbSet<PacienteMeta> PacienteMeta { get; set; }
        public virtual DbSet<PacienteMetaDiaria> PacienteMetaDiaria { get; set; }
        public virtual DbSet<PacienteMetaDiariaLog> PacienteMetaDiariaLog { get; set; }
        public virtual DbSet<Unidade> Unidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("User");

                b.Property(nameof(User.Nome)).HasMaxLength(150).HasColumnType("varchar").IsRequired();
                b.Property(nameof(User.Sobrenome)).HasMaxLength(150).HasColumnType("varchar").IsRequired();
                b.Property(nameof(User.Email)).HasMaxLength(150).HasColumnType("varchar").IsRequired();
                b.Property(nameof(User.UserName)).HasMaxLength(100).HasColumnType("varchar").IsRequired();
                b.Property(nameof(User.PhoneNumber)).HasMaxLength(15).HasColumnType("varchar").IsRequired();
                b.Property(nameof(User.Ip)).HasMaxLength(15).HasColumnType("varchar").IsRequired();
                b.Property(nameof(User.IntegracaoId)).HasMaxLength(50).HasColumnType("varchar");
                b.Property(nameof(User.DataNascimento)).HasColumnType("date").IsRequired();
                b.Property(nameof(User.DataCriacao)).HasColumnType("datetime").IsRequired();
                b.Property(nameof(User.DataAtualizacao)).HasColumnType("datetime");
                b.Property(nameof(User.Cpf)).HasColumnType("char(11)").IsRequired();
                b.Property(nameof(User.Sexo)).HasColumnType("char(1)");
                b.Property(nameof(User.PasswordHash)).HasMaxLength(300);
                b.Property(nameof(User.SecurityStamp)).HasMaxLength(300);
                b.Property(nameof(User.ConcurrencyStamp)).HasMaxLength(300);                
            });

            modelBuilder.Entity<UserClaim>(b =>
            {
                b.ToTable("UserClaim");

                b.Property(nameof(UserClaim.ClaimType)).HasMaxLength(100).HasColumnType("varchar").IsRequired();
                b.Property(nameof(UserClaim.ClaimValue)).HasMaxLength(300).HasColumnType("varchar").IsRequired();
            });

            modelBuilder.Entity<Role>(b =>
            {
                b.ToTable("Role");

                b.Property(nameof(Role.Name)).HasMaxLength(100).HasColumnType("varchar").IsRequired();
                b.Property(nameof(Role.NormalizedName)).HasMaxLength(100).HasColumnType("varchar").IsRequired();
                b.Property(nameof(Role.ConcurrencyStamp)).HasMaxLength(300);
            });

            modelBuilder.Entity<RoleClaim>(b =>
            {
                b.ToTable("RoleClaim");

                b.Property(nameof(RoleClaim.ClaimType)).HasMaxLength(100).HasColumnType("varchar").IsRequired();
                b.Property(nameof(RoleClaim.ClaimValue)).HasMaxLength(300).HasColumnType("varchar").IsRequired();
            });

            modelBuilder.Entity<UserRole>(b =>
            {
                b.ToTable("UserRole");
            });

            modelBuilder.Entity<UserLogin>(b =>
            {
                b.ToTable("UserLogin");

                b.Property(nameof(UserLogin.LoginProvider)).HasMaxLength(300).IsRequired();
                b.Property(nameof(UserLogin.ProviderKey)).HasMaxLength(300).IsRequired();
                b.Property(nameof(UserLogin.ProviderDisplayName)).HasMaxLength(300);
            });

            modelBuilder.Entity<UserToken>(b =>
            {
                b.ToTable("UserToken");

                b.Property(nameof(UserToken.LoginProvider)).HasMaxLength(300).IsRequired();
                b.Property(nameof(UserToken.Name)).HasMaxLength(300).IsRequired();                
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exercicio>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomePopular)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExercicioGrupo>(entity =>
            {
                entity.HasKey(e => new { e.ExercicioId, e.GrupoId });

                entity.HasIndex(e => e.GrupoId, "IX_ExercicioGrupo_GrupoId");

                entity.HasOne(d => d.Exercicio)
                    .WithMany(p => p.ExercicioGrupo)
                    .HasForeignKey(d => d.ExercicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioGrupo_Exercicio");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.ExercicioGrupo)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioGrupo_Grupo");
            });

            modelBuilder.Entity<ExercicioMetrica>(entity =>
            {
                entity.HasKey(e => new { e.ExercicioId, e.MetricaId });

                entity.HasIndex(e => e.MetricaId, "IX_ExercicioMetrica_MetricaId");

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercicio)
                    .WithMany(p => p.ExercicioMetrica)
                    .HasForeignKey(d => d.ExercicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioMetrica_Exercicio");

                entity.HasOne(d => d.Metrica)
                    .WithMany(p => p.ExercicioMetrica)
                    .HasForeignKey(d => d.MetricaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExercicioMetrica_Metrica");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Intervalo>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Meta>(entity =>
            {
                entity.HasIndex(e => e.EmpresaId, "IX_Meta_EmpresaId");

                entity.HasIndex(e => e.ExercicioId, "IX_Meta_ExercicioId");

                entity.HasIndex(e => e.IntervaloId, "IX_Meta_IntervaloId");

                entity.HasIndex(e => e.MetricaId, "IX_Meta_MetricaId");

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Empresa");

                entity.HasOne(d => d.Exercicio)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.ExercicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Exercicio");

                entity.HasOne(d => d.Intervalo)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.IntervaloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Intervalo");

                entity.HasOne(d => d.Metrica)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.MetricaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Metrica");
            });

            modelBuilder.Entity<Metrica>(entity =>
            {
                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PacienteMeta>(entity =>
            {
                entity.HasIndex(e => e.ExercicioId, "IX_PacienteMeta_ExercicioId");

                entity.HasIndex(e => e.IntervaloId, "IX_PacienteMeta_IntervaloId");

                entity.HasIndex(e => e.MetaId, "IX_PacienteMeta_MetaId");

                entity.HasIndex(e => e.MetricaId, "IX_PacienteMeta_MetricaId");

                entity.HasIndex(e => e.UserId, "IX_PacienteMeta_UserId");

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.DataFinal).HasColumnType("date");

                entity.Property(e => e.DataInicial).HasColumnType("date");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exercicio)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.ExercicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_Exercicio");

                entity.HasOne(d => d.Intervalo)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.IntervaloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_Intervalo");

                entity.HasOne(d => d.Meta)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.MetaId)
                    .HasConstraintName("FK_PacienteMeta_Meta");

                entity.HasOne(d => d.Metrica)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.MetricaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_Metrica");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PacienteMeta)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMeta_User");
            });

            modelBuilder.Entity<PacienteMetaDiaria>(entity =>
            {
                entity.HasIndex(e => e.PacienteMetaId, "IX_PacienteMetaDiaria_PacienteMetaId");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PacienteMeta)
                    .WithMany(p => p.PacienteMetaDiaria)
                    .HasForeignKey(d => d.PacienteMetaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMetaDiaria_PacienteMeta");
            });

            modelBuilder.Entity<PacienteMetaDiariaLog>(entity =>
            {
                entity.HasIndex(e => e.PacienteMetaDiariaId, "IX_PacienteMetaDiariaLog_PacienteMetaDiariaId");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PacienteMetaDiaria)
                    .WithMany(p => p.PacienteMetaDiariaLog)
                    .HasForeignKey(d => d.PacienteMetaDiariaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PacienteMetaDiariaLog_PacienteMetaDiaria");
            });

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.HasIndex(e => e.EmpresaId, "IX_Unidade_EmpresaId");

                entity.Property(e => e.Cnes)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataAtualizacao).HasColumnType("datetime");

                entity.Property(e => e.DataCriacao).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Unidade)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unidade_Empresa");
            });
        }
    }
}