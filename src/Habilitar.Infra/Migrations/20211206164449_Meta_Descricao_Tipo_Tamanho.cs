using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habilitar.Infra.Migrations
{
    public partial class Meta_Descricao_Tipo_Tamanho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Meta",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 44, 49, 126, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 44, 49, 126, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 44, 49, 126, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("05ff23c0-92cd-4806-b75b-1d71eb2f7a0f"), "e04f5011-d8f1-4514-9156-02122e6dec28", "Paciente", "PACIENTE" },
                    { new Guid("6e3ef3e3-674b-4333-9c70-44503526de85"), "acf3a754-3f74-4071-8551-a757bc297849", "Fisioterapeuta", "FISIOTERAPEUTA" },
                    { new Guid("a6b438e4-95ca-4a4f-94bf-770286734d59"), "9a87e700-8529-4bfa-acf0-d9bc710b6b5b", "Admin", "ADMIN" },
                    { new Guid("c228d922-37c0-48f7-88d5-e1a361d37f29"), "ce85e839-fd43-41c9-82ed-4cd1139d1222", "Auxiliar", "AUXILIAR" }
                });

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 44, 49, 128, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 44, 49, 128, DateTimeKind.Local).AddTicks(1808));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("05ff23c0-92cd-4806-b75b-1d71eb2f7a0f"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6e3ef3e3-674b-4333-9c70-44503526de85"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a6b438e4-95ca-4a4f-94bf-770286734d59"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c228d922-37c0-48f7-88d5-e1a361d37f29"));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Meta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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
    }
}
