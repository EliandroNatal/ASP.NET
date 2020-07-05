using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EliandroProjetoManha.Migrations
{
    public partial class SegundaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departamento",
                newName: "PedidoId");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Produto = table.Column<string>(nullable: true),
                    Fornecedor = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    DepartamentoPedidoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Pedido_Departamento_DepartamentoPedidoId",
                        column: x => x.DepartamentoPedidoId,
                        principalTable: "Departamento",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroPedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Horario = table.Column<DateTime>(nullable: false),
                    Quantia = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PedidoProdutoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_RegistroPedidos_Pedido_PedidoProdutoId",
                        column: x => x.PedidoProdutoId,
                        principalTable: "Pedido",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_DepartamentoPedidoId",
                table: "Pedido",
                column: "DepartamentoPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPedidos_PedidoProdutoId",
                table: "RegistroPedidos",
                column: "PedidoProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroPedidos");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "Departamento",
                newName: "Id");
        }
    }
}
