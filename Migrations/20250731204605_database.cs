using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paddockCcell.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "celulares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tela = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_celulares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orcamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CondicaoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orcamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ordemServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHoraAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Servico = table.Column<int>(type: "int", nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    DadosEquipamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoProblema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordemServicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeServico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorServico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrcamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servicos_orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "orcamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_servicos_OrcamentoId",
                table: "servicos",
                column: "OrcamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "celulares");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "ordemServicos");

            migrationBuilder.DropTable(
                name: "servicos");

            migrationBuilder.DropTable(
                name: "orcamentos");
        }
    }
}
