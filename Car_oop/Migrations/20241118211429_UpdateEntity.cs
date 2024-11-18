using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_oop.Migrations
{
    public partial class UpdateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Удаляем внешний ключ, если он существует
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Posts_PostId",  // Имя внешнего ключа (проверьте в базе данных)
                table: "Persons");

            // Удаляем индекс
            migrationBuilder.DropIndex(
                name: "IX_Persons_PostId",
                table: "Persons");

            // Создаём новый индекс
            migrationBuilder.CreateIndex(
                name: "IX_Persons_PostId",
                table: "Persons",
                column: "PostId");

            // Восстанавливаем внешний ключ
            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Posts_PostId",  // Имя внешнего ключа (проверьте в базе данных)
                table: "Persons",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаляем внешний ключ
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Posts_PostId",  // Имя внешнего ключа
                table: "Persons");

            // Удаляем индекс
            migrationBuilder.DropIndex(
                name: "IX_Persons_PostId",
                table: "Persons");

            // Восстанавливаем индекс с уникальностью
            migrationBuilder.CreateIndex(
                name: "IX_Persons_PostId",
                table: "Persons",
                column: "PostId",
                unique: true);

            // Восстанавливаем внешний ключ
            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Posts_PostId",  // Имя внешнего ключа
                table: "Persons",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
