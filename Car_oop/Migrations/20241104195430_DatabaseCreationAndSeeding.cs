using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car_oop.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreationAndSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clientPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    passport = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModelCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bodyType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    brand = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    count = table.Column<int>(type: "int", nullable: false),
                    driveType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    firm = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fuelType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mileage = table.Column<int>(type: "int", nullable: false),
                    model = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<double>(type: "double", nullable: false),
                    transmissionType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    yearRealse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelCar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    paymentMethod = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    namePost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModelCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_ModelCar_ModelCarId",
                        column: x => x.ModelCarId,
                        principalTable: "ModelCar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    experience = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    price = table.Column<double>(type: "double", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    PaymentMetgodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMetgodId",
                        column: x => x.PaymentMetgodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "clientPhone", "email", "name", "passport", "surname" },
                values: new object[,]
                {
                    { 1, "123-456-7890", "john@example.com", "John", "AB123456", "Doe" },
                    { 2, "987-654-3210", "jane@example.com", "Jane", "CD789012", "Smith" },
                    { 3, "555-123-4567", "michael@example.com", "Michael", "EF345678", "Johnson" },
                    { 4, "444-987-6543", "emily@example.com", "Emily", "GH901234", "Williams" },
                    { 5, "333-654-7890", "david@example.com", "David", "IJ567890", "Brown" }
                });

            migrationBuilder.InsertData(
                table: "ModelCar",
                columns: new[] { "Id", "bodyType", "brand", "color", "count", "driveType", "firm", "fuelType", "mileage", "model", "price", "transmissionType", "yearRealse" },
                values: new object[,]
                {
                    { 1, "Sedan", "Toyota", "Red", 10, "FWD", "Toyota", "Gasoline", 0, "Camry", 30000.0, "Automatic", 2023 },
                    { 2, "SUV", "Honda", "Blue", 7, "AWD", "Honda", "Gasoline", 0, "CR-V", 35000.0, "Automatic", 2023 },
                    { 3, "Truck", "Ford", "Black", 5, "4WD", "Ford", "Diesel", 0, "F-150", 45000.0, "Automatic", 2023 },
                    { 4, "Coupe", "BMW", "White", 3, "RWD", "BMW", "Gasoline", 0, "M4", 70000.0, "Manual", 2023 },
                    { 5, "Hatchback", "Volkswagen", "Green", 8, "FWD", "Volkswagen", "Gasoline", 0, "Golf", 25000.0, "Automatic", 2023 }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "paymentMethod" },
                values: new object[,]
                {
                    { 1, "Credit Card" },
                    { 2, "Cash" },
                    { 3, "Bank Transfer" },
                    { 4, "Financing" },
                    { 5, "Leasing" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "namePost" },
                values: new object[,]
                {
                    { 1, "Sales Manager" },
                    { 2, "Service Technician" },
                    { 3, "Finance Manager" },
                    { 4, "Customer Service Representative" },
                    { 5, "Detailer" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ModelCarId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "PostId", "experience", "name", "surname" },
                values: new object[,]
                {
                    { 1, 1, 5, "Alice", "Johnson" },
                    { 2, 2, 3, "Bob", "Brown" },
                    { 3, 3, 10, "Charlie", "Davis" },
                    { 4, 4, 2, "Diana", "Miller" },
                    { 5, 5, 1, "Edward", "Wilson" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CarId", "ClientId", "PaymentMetgodId", "PersonId", "orderDate", "price", "status" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000.0, "Completed" },
                    { 2, 2, 2, 2, 2, new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 35000.0, "Pending" },
                    { 3, 3, 3, 3, 3, new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000.0, "Completed" },
                    { 4, 4, 4, 4, 4, new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 70000.0, "Pending" },
                    { 5, 5, 5, 5, 5, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000.0, "Completed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelCarId",
                table: "Cars",
                column: "ModelCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMetgodId",
                table: "Orders",
                column: "PaymentMetgodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonId",
                table: "Orders",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PostId",
                table: "Persons",
                column: "PostId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "ModelCar");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
