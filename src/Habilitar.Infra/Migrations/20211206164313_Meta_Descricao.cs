using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habilitar.Infra.Migrations
{
    public partial class Meta_Descricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2bd04c45-2d01-4f59-96fd-fee64e8f0df9"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("30636c81-679b-414c-9791-ddaf6b58b1b9"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7e729b28-7a7e-4952-aa1c-59a671e3b87c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7e81e290-7d5e-4203-8bd6-2733dc46aee4"));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Meta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 43, 13, 63, DateTimeKind.Local).AddTicks(1258));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 43, 13, 63, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 43, 13, 63, DateTimeKind.Local).AddTicks(1270));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1bec17d9-37a0-424e-bdd0-d0302fe407e0"), "a7ce78ce-20d2-4558-be7e-43b52aa9125c", "Admin", "ADMIN" },
                    { new Guid("807e1266-cff7-4104-8bf7-d6c5de7568df"), "27ec2908-dfae-4a59-88a1-d314745dfef0", "Auxiliar", "AUXILIAR" },
                    { new Guid("b15787bc-d1f2-4e8a-a0a4-c0bada40847e"), "16a3caf4-4c85-4693-b221-1dd3f2cfc07c", "Fisioterapeuta", "FISIOTERAPEUTA" },
                    { new Guid("c9d756ed-24a3-48f7-b9cb-0124d5975239"), "74305263-d7c4-44a6-a81a-680ea7d6e535", "Paciente", "PACIENTE" }
                });

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 43, 13, 65, DateTimeKind.Local).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 43, 13, 65, DateTimeKind.Local).AddTicks(1402));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("1bec17d9-37a0-424e-bdd0-d0302fe407e0"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("807e1266-cff7-4104-8bf7-d6c5de7568df"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b15787bc-d1f2-4e8a-a0a4-c0bada40847e"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c9d756ed-24a3-48f7-b9cb-0124d5975239"));

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Meta");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 41, 11, 879, DateTimeKind.Local).AddTicks(9013));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 41, 11, 879, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 41, 11, 879, DateTimeKind.Local).AddTicks(9023));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2bd04c45-2d01-4f59-96fd-fee64e8f0df9"), "a9004928-95de-4ba7-8d2a-ce93d9ee8357", "Paciente", "PACIENTE" },
                    { new Guid("30636c81-679b-414c-9791-ddaf6b58b1b9"), "c7e1bbec-5b42-4e89-8182-f5550e3a2cd1", "Admin", "ADMIN" },
                    { new Guid("7e729b28-7a7e-4952-aa1c-59a671e3b87c"), "7ed19e36-aac3-4714-8582-1173aabeff3d", "Fisioterapeuta", "FISIOTERAPEUTA" },
                    { new Guid("7e81e290-7d5e-4203-8bd6-2733dc46aee4"), "8a3e2a85-a909-4303-92a0-09a4d3de552c", "Auxiliar", "AUXILIAR" }
                });

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 41, 11, 881, DateTimeKind.Local).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 41, 11, 881, DateTimeKind.Local).AddTicks(7827));
        }
    }
}
