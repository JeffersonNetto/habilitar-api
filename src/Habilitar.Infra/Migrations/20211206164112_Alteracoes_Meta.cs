using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Habilitar.Infra.Migrations
{
    public partial class Alteracoes_Meta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meta_Empresa",
                table: "Meta");

            migrationBuilder.DropIndex(
                name: "IX_Meta_EmpresaId",
                table: "Meta");

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

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Meta");

            migrationBuilder.DropColumn(
                name: "FisioterapeutaId",
                table: "Meta");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataCriacao", "Ip" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 41, 11, 879, DateTimeKind.Local).AddTicks(9013), "localhost" });

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataCriacao", "Ip" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 41, 11, 879, DateTimeKind.Local).AddTicks(9022), "localhost" });

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataCriacao", "Ip" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 41, 11, 879, DateTimeKind.Local).AddTicks(9023), "localhost" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Meta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FisioterapeutaId",
                table: "Meta",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataCriacao", "Ip" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 19, 45, 407, DateTimeKind.Local).AddTicks(2119), "::1" });

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataCriacao", "Ip" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 19, 45, 407, DateTimeKind.Local).AddTicks(2133), "::1" });

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataCriacao", "Ip" },
                values: new object[] { new DateTime(2021, 12, 6, 13, 19, 45, 407, DateTimeKind.Local).AddTicks(2134), "::1" });

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

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 19, 45, 409, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2021, 12, 6, 13, 19, 45, 409, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.CreateIndex(
                name: "IX_Meta_EmpresaId",
                table: "Meta",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meta_Empresa",
                table: "Meta",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }
    }
}
