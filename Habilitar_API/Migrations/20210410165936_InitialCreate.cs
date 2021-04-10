using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Habilitar_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    QtdSeries = table.Column<int>(type: "int", nullable: false),
                    MetricaId = table.Column<short>(type: "smallint", nullable: false),
                    MetricaQtd = table.Column<int>(type: "int", nullable: false),
                    IntervaloId = table.Column<short>(type: "smallint", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    FisioterapeutaId = table.Column<int>(type: "int", nullable: true),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Cnes = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Latitude = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Longitude = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExercicioGrupo",
                columns: table => new
                {
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioGrupo", x => new { x.ExercicioId, x.GrupoId });
                });

            migrationBuilder.CreateTable(
                name: "ExercicioMetrica",
                columns: table => new
                {
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    MetricaId = table.Column<short>(type: "smallint", nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioMetrica", x => new { x.ExercicioId, x.MetricaId });
                });

            migrationBuilder.CreateTable(
                name: "PacienteMeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    MetaId = table.Column<int>(type: "int", nullable: true),
                    FisioterapeutaId = table.Column<int>(type: "int", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "date", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "date", nullable: false),
                    ExercicioId = table.Column<int>(type: "int", nullable: false),
                    QtdSeries = table.Column<int>(type: "int", nullable: false),
                    MetricaId = table.Column<short>(type: "smallint", nullable: false),
                    MetricaQtd = table.Column<int>(type: "int", nullable: false),
                    IntervaloId = table.Column<short>(type: "smallint", nullable: false),
                    Domingo = table.Column<bool>(type: "bit", nullable: false),
                    SegundaFeira = table.Column<bool>(type: "bit", nullable: false),
                    TercaFeira = table.Column<bool>(type: "bit", nullable: false),
                    QuartaFeira = table.Column<bool>(type: "bit", nullable: false),
                    QuintaFeira = table.Column<bool>(type: "bit", nullable: false),
                    SextaFeira = table.Column<bool>(type: "bit", nullable: false),
                    Sabado = table.Column<bool>(type: "bit", nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteMeta_Meta",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PacienteMetaDiaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteMetaId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    MetricaQtd = table.Column<int>(type: "int", nullable: false),
                    QtdRealizado = table.Column<int>(type: "int", nullable: true),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteMetaDiaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteMetaDiaria_PacienteMeta",
                        column: x => x.PacienteMetaId,
                        principalTable: "PacienteMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PacienteMetaDiariaLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteMetaDiariaId = table.Column<int>(type: "int", nullable: false),
                    QtdRealizado = table.Column<int>(type: "int", nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteMetaDiariaLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteMetaDiariaLog_PacienteMetaDiaria",
                        column: x => x.PacienteMetaDiariaId,
                        principalTable: "PacienteMetaDiaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerfilFuncao",
                columns: table => new
                {
                    PerfilId = table.Column<int>(type: "int", nullable: false),
                    FuncaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilFuncao", x => new { x.PerfilId, x.FuncaoId });
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPerfil",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfil", x => new { x.UsuarioId, x.PerfilId });
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    UnidadeId = table.Column<int>(type: "int", nullable: true),
                    Profissional = table.Column<bool>(type: "bit", nullable: false),
                    Fisioterapeuta = table.Column<bool>(type: "bit", nullable: false),
                    Conselho = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Unidade",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFantasia = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    Cnpj = table.Column<string>(type: "char(14)", unicode: false, fixedLength: true, maxLength: 14, nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_UsuarioAtualizacao",
                        column: x => x.UsuarioAtualizacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresa_UsuarioCriacao",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NomePopular = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Url = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicio_UsuarioAtualizacao",
                        column: x => x.UsuarioAtualizacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercicio_UsuarioCriacao",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Observacao = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcao_UsuarioAtualizacao",
                        column: x => x.UsuarioAtualizacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcao_UsuarioCriacao",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Observacao = table.Column<byte[]>(type: "varbinary(200)", maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupo_UsuarioAtualizacao",
                        column: x => x.UsuarioAtualizacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupo_UsuarioCriacao",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Intervalo",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervalo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intervalo_UsuarioAtualizacao",
                        column: x => x.UsuarioAtualizacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intervalo_UsuarioCriacao",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogAcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAcesso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogAcesso_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogErro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Erro = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    Acao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Tela = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogErro_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Metrica",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Observacao = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metrica_UsuarioAtualizacao",
                        column: x => x.UsuarioAtualizacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Metrica_UsuarioCriacao",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Observacao = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfil_UsuarioAtualizacao",
                        column: x => x.UsuarioAtualizacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Perfil_UsuarioCriacao",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Cpf = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    IntegracaoId = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_UsuarioAtualizacao",
                        column: x => x.UsuarioAtualizacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoa_UsuarioCriacao",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_UsuarioAtualizacaoId",
                table: "Empresa",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_UsuarioCriacaoId",
                table: "Empresa",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_UsuarioAtualizacaoId",
                table: "Exercicio",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_UsuarioCriacaoId",
                table: "Exercicio",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioGrupo_GrupoId",
                table: "ExercicioGrupo",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioGrupo_UsuarioAtualizacaoId",
                table: "ExercicioGrupo",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioGrupo_UsuarioCriacaoId",
                table: "ExercicioGrupo",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioMetrica_MetricaId",
                table: "ExercicioMetrica",
                column: "MetricaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioMetrica_UsuarioAtualizacaoId",
                table: "ExercicioMetrica",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioMetrica_UsuarioCriacaoId",
                table: "ExercicioMetrica",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcao_UsuarioAtualizacaoId",
                table: "Funcao",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcao_UsuarioCriacaoId",
                table: "Funcao",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_UsuarioAtualizacaoId",
                table: "Grupo",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_UsuarioCriacaoId",
                table: "Grupo",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervalo_UsuarioAtualizacaoId",
                table: "Intervalo",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervalo_UsuarioCriacaoId",
                table: "Intervalo",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LogAcesso_UsuarioId",
                table: "LogAcesso",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LogErro_UsuarioId",
                table: "LogErro",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_EmpresaId",
                table: "Meta",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_ExercicioId",
                table: "Meta",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_FisioterapeutaId",
                table: "Meta",
                column: "FisioterapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_IntervaloId",
                table: "Meta",
                column: "IntervaloId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_MetricaId",
                table: "Meta",
                column: "MetricaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_UsuarioAtualizacaoId",
                table: "Meta",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_UsuarioCriacaoId",
                table: "Meta",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Metrica_UsuarioAtualizacaoId",
                table: "Metrica",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Metrica_UsuarioCriacaoId",
                table: "Metrica",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMeta_ExercicioId",
                table: "PacienteMeta",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMeta_FisioterapeutaId",
                table: "PacienteMeta",
                column: "FisioterapeutaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMeta_IntervaloId",
                table: "PacienteMeta",
                column: "IntervaloId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMeta_MetaId",
                table: "PacienteMeta",
                column: "MetaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMeta_MetricaId",
                table: "PacienteMeta",
                column: "MetricaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMeta_PessoaId",
                table: "PacienteMeta",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMeta_UsuarioAtualizacaoId",
                table: "PacienteMeta",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMeta_UsuarioCriacaoId",
                table: "PacienteMeta",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMetaDiaria_PacienteMetaId",
                table: "PacienteMetaDiaria",
                column: "PacienteMetaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMetaDiariaLog_PacienteMetaDiariaId",
                table: "PacienteMetaDiariaLog",
                column: "PacienteMetaDiariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_UsuarioAtualizacaoId",
                table: "Perfil",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_UsuarioCriacaoId",
                table: "Perfil",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilFuncao_FuncaoId",
                table: "PerfilFuncao",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilFuncao_UsuarioCriacaoId",
                table: "PerfilFuncao",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_UsuarioAtualizacaoId",
                table: "Pessoa",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_UsuarioCriacaoId",
                table: "Pessoa",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_EmpresaId",
                table: "Unidade",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_UsuarioAtualizacaoId",
                table: "Unidade",
                column: "UsuarioAtualizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_UsuarioCriacaoId",
                table: "Unidade",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoaId",
                table: "Usuario",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UnidadeId",
                table: "Usuario",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_PerfilId",
                table: "UsuarioPerfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_UsuarioCriacaoId",
                table: "UsuarioPerfil",
                column: "UsuarioCriacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meta_Empresa",
                table: "Meta",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meta_Exercicio",
                table: "Meta",
                column: "ExercicioId",
                principalTable: "Exercicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meta_Fisioterapeuta",
                table: "Meta",
                column: "FisioterapeutaId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meta_UsuarioAtualizacao",
                table: "Meta",
                column: "UsuarioAtualizacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meta_UsuarioCriacao",
                table: "Meta",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meta_Intervalo",
                table: "Meta",
                column: "IntervaloId",
                principalTable: "Intervalo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meta_Metrica",
                table: "Meta",
                column: "MetricaId",
                principalTable: "Metrica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidade_Empresa",
                table: "Unidade",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidade_UsuarioAtualizacao",
                table: "Unidade",
                column: "UsuarioAtualizacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidade_UsuarioCriacao",
                table: "Unidade",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioGrupo_Exercicio",
                table: "ExercicioGrupo",
                column: "ExercicioId",
                principalTable: "Exercicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioGrupo_Grupo",
                table: "ExercicioGrupo",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioGrupo_UsuarioAtualizacao",
                table: "ExercicioGrupo",
                column: "UsuarioAtualizacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioGrupo_UsuarioCriacao",
                table: "ExercicioGrupo",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioMetrica_Exercicio",
                table: "ExercicioMetrica",
                column: "ExercicioId",
                principalTable: "Exercicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioMetrica_Metrica",
                table: "ExercicioMetrica",
                column: "MetricaId",
                principalTable: "Metrica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioMetrica_UsuarioAtualizacao",
                table: "ExercicioMetrica",
                column: "UsuarioAtualizacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercicioMetrica_UsuarioCriacao",
                table: "ExercicioMetrica",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteMeta_Exercicio",
                table: "PacienteMeta",
                column: "ExercicioId",
                principalTable: "Exercicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteMeta_Intervalo",
                table: "PacienteMeta",
                column: "IntervaloId",
                principalTable: "Intervalo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteMeta_Metrica",
                table: "PacienteMeta",
                column: "MetricaId",
                principalTable: "Metrica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteMeta_Pessoa",
                table: "PacienteMeta",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteMeta_Usuario",
                table: "PacienteMeta",
                column: "FisioterapeutaId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteMeta_UsuarioAtualizacao",
                table: "PacienteMeta",
                column: "UsuarioAtualizacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PacienteMeta_UsuarioCriacao",
                table: "PacienteMeta",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilFuncao_Funcao",
                table: "PerfilFuncao",
                column: "FuncaoId",
                principalTable: "Funcao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilFuncao_Perfil",
                table: "PerfilFuncao",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfilFuncao_UsuarioCriacao",
                table: "PerfilFuncao",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioPerfil_Perfil",
                table: "UsuarioPerfil",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioPerfil_Usuario",
                table: "UsuarioPerfil",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioPerfil_UsuarioCriacao",
                table: "UsuarioPerfil",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Pessoa",
                table: "Usuario",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_UsuarioAtualizacao",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_UsuarioCriacao",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_UsuarioAtualizacao",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_UsuarioCriacao",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidade_UsuarioAtualizacao",
                table: "Unidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidade_UsuarioCriacao",
                table: "Unidade");

            migrationBuilder.DropTable(
                name: "ExercicioGrupo");

            migrationBuilder.DropTable(
                name: "ExercicioMetrica");

            migrationBuilder.DropTable(
                name: "LogAcesso");

            migrationBuilder.DropTable(
                name: "LogErro");

            migrationBuilder.DropTable(
                name: "PacienteMetaDiariaLog");

            migrationBuilder.DropTable(
                name: "PerfilFuncao");

            migrationBuilder.DropTable(
                name: "UsuarioPerfil");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "PacienteMetaDiaria");

            migrationBuilder.DropTable(
                name: "Funcao");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "PacienteMeta");

            migrationBuilder.DropTable(
                name: "Meta");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "Intervalo");

            migrationBuilder.DropTable(
                name: "Metrica");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
