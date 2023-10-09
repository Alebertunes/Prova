using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Folha_de_Pagamento.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "FolhaDePagamentos",
                columns: table => new
                {
                    FolhaDePagamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<double>(type: "REAL", nullable: true),
                    Quantidade = table.Column<double>(type: "REAL", nullable: true),
                    Mes = table.Column<int>(type: "INTEGER", nullable: true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: true),
                    salarioBruto = table.Column<double>(type: "REAL", nullable: true),
                    impostoIrrf = table.Column<double>(type: "REAL", nullable: true),
                    impostoInss = table.Column<double>(type: "REAL", nullable: true),
                    impostoFgts = table.Column<double>(type: "REAL", nullable: true),
                    SalarioLiquido = table.Column<double>(type: "REAL", nullable: true),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolhaDePagamentos", x => x.FolhaDePagamentoId);
                    table.ForeignKey(
                        name: "FK_FolhaDePagamentos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FolhaDePagamentos_FuncionarioId",
                table: "FolhaDePagamentos",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FolhaDePagamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
