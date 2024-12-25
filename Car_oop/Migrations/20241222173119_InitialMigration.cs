using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_oop.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Удаляем внешний ключ
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMetgodId",
                table: "Orders");

            // Удаляем индекс
            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMetgodId",
                table: "Orders");

            // Создаём новый индекс (если требуется)
            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMetgodId",
                table: "Orders",
                column: "PaymentMetgodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Восстанавливаем индекс
            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMetgodId",
                table: "Orders");

            // Восстанавливаем внешний ключ
            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMetgodId",
                table: "Orders",
                column: "PaymentMetgodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

    }
}
