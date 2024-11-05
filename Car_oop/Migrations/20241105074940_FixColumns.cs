using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_oop.Migrations
{
    /// <inheritdoc />
    public partial class FixColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "mileage",
                table: "ModelCar");

            migrationBuilder.AddColumn<double>(
                name: "payday",
                table: "Persons",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "payday",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                column: "payday",
                value: 2000.0);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                column: "payday",
                value: 3000.0);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4,
                column: "payday",
                value: 4000.0);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5,
                column: "payday",
                value: 1000.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "payday",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "mileage",
                table: "ModelCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ModelCar",
                keyColumn: "Id",
                keyValue: 1,
                column: "mileage",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ModelCar",
                keyColumn: "Id",
                keyValue: 2,
                column: "mileage",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ModelCar",
                keyColumn: "Id",
                keyValue: 3,
                column: "mileage",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ModelCar",
                keyColumn: "Id",
                keyValue: 4,
                column: "mileage",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ModelCar",
                keyColumn: "Id",
                keyValue: 5,
                column: "mileage",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
