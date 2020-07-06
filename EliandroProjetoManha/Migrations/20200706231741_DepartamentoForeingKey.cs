using Microsoft.EntityFrameworkCore.Migrations;

namespace EliandroProjetoManha.Migrations
{
    public partial class DepartamentoForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Departamento_DepartamentoPedidoId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_DepartamentoPedidoId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "DepartamentoPedidoId",
                table: "Pedido");

            migrationBuilder.AlterColumn<string>(
                name: "Produto",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_DepartamentoId",
                table: "Pedido",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Departamento_DepartamentoId",
                table: "Pedido",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Departamento_DepartamentoId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_DepartamentoId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Pedido");

            migrationBuilder.AlterColumn<string>(
                name: "Produto",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoPedidoId",
                table: "Pedido",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_DepartamentoPedidoId",
                table: "Pedido",
                column: "DepartamentoPedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Departamento_DepartamentoPedidoId",
                table: "Pedido",
                column: "DepartamentoPedidoId",
                principalTable: "Departamento",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
