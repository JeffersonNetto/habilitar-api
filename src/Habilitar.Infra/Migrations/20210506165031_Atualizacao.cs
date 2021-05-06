using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Habilitar.Infra.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
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
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Observacao = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
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
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervalo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogAcesso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAcesso", x => x.Id);
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
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErro", x => x.Id);
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
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metrica", x => x.Id);
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntegracaoId = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Ip = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
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
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidade_Empresa",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioGrupo", x => new { x.ExercicioId, x.GrupoId });
                    table.ForeignKey(
                        name: "FK_ExercicioGrupo_Exercicio",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExercicioGrupo_Grupo",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercicioMetrica", x => new { x.ExercicioId, x.MetricaId });
                    table.ForeignKey(
                        name: "FK_ExercicioMetrica_Exercicio",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExercicioMetrica_Metrica",
                        column: x => x.MetricaId,
                        principalTable: "Metrica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meta_Empresa",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meta_Exercicio",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meta_Intervalo",
                        column: x => x.IntervaloId,
                        principalTable: "Intervalo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meta_Metrica",
                        column: x => x.MetricaId,
                        principalTable: "Metrica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UsuarioCriacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteMeta_Exercicio",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacienteMeta_Intervalo",
                        column: x => x.IntervaloId,
                        principalTable: "Intervalo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacienteMeta_Meta",
                        column: x => x.MetaId,
                        principalTable: "Meta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacienteMeta_Metrica",
                        column: x => x.MetricaId,
                        principalTable: "Metrica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacienteMeta_Pessoa",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
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

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioGrupo_GrupoId",
                table: "ExercicioGrupo",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercicioMetrica_MetricaId",
                table: "ExercicioMetrica",
                column: "MetricaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_EmpresaId",
                table: "Meta",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_ExercicioId",
                table: "Meta",
                column: "ExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_IntervaloId",
                table: "Meta",
                column: "IntervaloId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_MetricaId",
                table: "Meta",
                column: "MetricaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMeta_ExercicioId",
                table: "PacienteMeta",
                column: "ExercicioId");

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
                name: "IX_PacienteMetaDiaria_PacienteMetaId",
                table: "PacienteMetaDiaria",
                column: "PacienteMetaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteMetaDiariaLog_PacienteMetaDiariaId",
                table: "PacienteMetaDiariaLog",
                column: "PacienteMetaDiariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_EmpresaId",
                table: "Unidade",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "PacienteMetaDiaria");

            migrationBuilder.DropTable(
                name: "PacienteMeta");

            migrationBuilder.DropTable(
                name: "Meta");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "Intervalo");

            migrationBuilder.DropTable(
                name: "Metrica");
        }
    }
}
