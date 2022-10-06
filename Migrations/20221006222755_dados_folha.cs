using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FOlhas.Migrations
{
    public partial class dados_folha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatadaFolha",
                table: "Folhas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpostoFgts",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpostoInss",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpostoRenda",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadedeHoras",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalarioLiquido",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValorHora",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_FuncionarioId",
                table: "Folhas",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folhas_Funcionarios_FuncionarioId",
                table: "Folhas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folhas_Funcionarios_FuncionarioId",
                table: "Folhas");

            migrationBuilder.DropIndex(
                name: "IX_Folhas_FuncionarioId",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "DatadaFolha",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "ImpostoFgts",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "ImpostoInss",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "ImpostoRenda",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "QuantidadedeHoras",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "SalarioLiquido",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "ValorHora",
                table: "Folhas");
        }
    }
}
