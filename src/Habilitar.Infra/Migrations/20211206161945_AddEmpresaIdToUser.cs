using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habilitar.Infra.Migrations
{
    public partial class AddEmpresaIdToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Ativo", "Cnpj", "DataAtualizacao", "DataCriacao", "Ip", "NomeFantasia", "RazaoSocial", "UsuarioAtualizacaoId", "UsuarioCriacaoId" },
                values: new object[,]
                {
                    { 1, true, "19878404000100", null, new DateTime(2021, 12, 6, 13, 19, 45, 407, DateTimeKind.Local).AddTicks(2119), "::1", "Fundação São Francisco Xavier", "Fundação São Francisco Xavier", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, true, "05815928000148", null, new DateTime(2021, 12, 6, 13, 19, 45, 407, DateTimeKind.Local).AddTicks(2133), "::1", "Fisiocenter", "Fisiocenter", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { 3, true, "04720047000180", null, new DateTime(2021, 12, 6, 13, 19, 45, 407, DateTimeKind.Local).AddTicks(2134), "::1", "Posturar Clinica de Fisioterapia LTDA", "Posturar Clinica de Fisioterapia LTDA", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3ff20c8e-e4ca-4afb-a859-bcb37509683b"), "0c1100bc-5139-4252-bb41-b10a55da2867", "Paciente", "PACIENTE" },
                    { new Guid("fb3df231-9d6d-45d5-8ac9-65fba7fa422e"), "8dcfd796-4bbd-43ed-a0c9-d0c038e7f116", "Fisioterapeuta", "FISIOTERAPEUTA" },
                    { new Guid("fe466078-a524-4a78-811b-b5c5d50508fe"), "8075a80d-9876-4613-8332-3d9a22ab4f62", "Admin", "ADMIN" },
                    { new Guid("ff5b46e5-4501-47a4-a14f-65644d31b2c4"), "159bbc04-bfce-4676-a5d2-4e4322ba3a80", "Auxiliar", "AUXILIAR" }
                });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Ativo", "Cnes", "DataAtualizacao", "DataCriacao", "Email", "EmpresaId", "Ip", "Latitude", "Longitude", "Nome", "Telefone", "UsuarioAtualizacaoId", "UsuarioCriacaoId" },
                values: new object[] { 1, true, "2440A", null, new DateTime(2021, 12, 6, 13, 19, 45, 409, DateTimeKind.Local).AddTicks(3667), "teste@fsfx.com.br", 1, "::1", "-19.49523868306967", "-42.5379800827425", "HMC I", "03138299000", null, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Ativo", "Cnes", "DataAtualizacao", "DataCriacao", "Email", "EmpresaId", "Ip", "Latitude", "Longitude", "Nome", "Telefone", "UsuarioAtualizacaoId", "UsuarioCriacaoId" },
                values: new object[] { 2, true, "2440A", null, new DateTime(2021, 12, 6, 13, 19, 45, 409, DateTimeKind.Local).AddTicks(3678), "teste@fsfx.com.br", 1, "::1", "-19.507606869177867", "-42.55770305020517", "HMC II", "03138299000", null, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_User_EmpresaId",
                table: "User",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Empresa_EmpresaId",
                table: "User",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Empresa_EmpresaId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_EmpresaId",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3ff20c8e-e4ca-4afb-a859-bcb37509683b"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("fb3df231-9d6d-45d5-8ac9-65fba7fa422e"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("fe466078-a524-4a78-811b-b5c5d50508fe"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ff5b46e5-4501-47a4-a14f-65644d31b2c4"));

            migrationBuilder.DeleteData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "User");
        }
    }
}
