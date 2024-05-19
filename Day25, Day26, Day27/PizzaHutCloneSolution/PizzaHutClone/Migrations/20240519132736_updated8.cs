using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaHutClone.Migrations
{
    /// <inheritdoc />
    public partial class updated8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Pizzas",
                newName: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SellerId",
                table: "Pizzas",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Customers_SellerId",
                table: "Pizzas",
                column: "SellerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Customers_SellerId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_SellerId",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Pizzas",
                newName: "CreatedBy");
        }
    }
}
