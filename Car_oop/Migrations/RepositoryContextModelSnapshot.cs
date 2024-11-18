﻿// <auto-generated />
using System;
using Car_oop.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Car_oop.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Car_oop.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ModelCarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelCarId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ModelCarId = 1
                        },
                        new
                        {
                            Id = 2,
                            ModelCarId = 2
                        },
                        new
                        {
                            Id = 3,
                            ModelCarId = 3
                        },
                        new
                        {
                            Id = 4,
                            ModelCarId = 4
                        },
                        new
                        {
                            Id = 5,
                            ModelCarId = 5
                        });
                });

            modelBuilder.Entity("Car_oop.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("clientPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("passport")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            clientPhone = "123-456-7890",
                            email = "john@example.com",
                            name = "John",
                            passport = "AB123456",
                            surname = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            clientPhone = "987-654-3210",
                            email = "jane@example.com",
                            name = "Jane",
                            passport = "CD789012",
                            surname = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            clientPhone = "555-123-4567",
                            email = "michael@example.com",
                            name = "Michael",
                            passport = "EF345678",
                            surname = "Johnson"
                        },
                        new
                        {
                            Id = 4,
                            clientPhone = "444-987-6543",
                            email = "emily@example.com",
                            name = "Emily",
                            passport = "GH901234",
                            surname = "Williams"
                        },
                        new
                        {
                            Id = 5,
                            clientPhone = "333-654-7890",
                            email = "david@example.com",
                            name = "David",
                            passport = "IJ567890",
                            surname = "Brown"
                        });
                });

            modelBuilder.Entity("Car_oop.Models.ModelCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("bodyType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.Property<string>("driveType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("firm")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("fuelType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<string>("transmissionType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("yearRealse")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ModelCar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            bodyType = "Sedan",
                            brand = "Toyota",
                            color = "Red",
                            count = 10,
                            driveType = "FWD",
                            firm = "Toyota",
                            fuelType = "Gasoline",
                            model = "Camry",
                            price = 30000.0,
                            transmissionType = "Automatic",
                            yearRealse = 2023
                        },
                        new
                        {
                            Id = 2,
                            bodyType = "SUV",
                            brand = "Honda",
                            color = "Blue",
                            count = 7,
                            driveType = "AWD",
                            firm = "Honda",
                            fuelType = "Gasoline",
                            model = "CR-V",
                            price = 35000.0,
                            transmissionType = "Automatic",
                            yearRealse = 2023
                        },
                        new
                        {
                            Id = 3,
                            bodyType = "Truck",
                            brand = "Ford",
                            color = "Black",
                            count = 5,
                            driveType = "4WD",
                            firm = "Ford",
                            fuelType = "Diesel",
                            model = "F-150",
                            price = 45000.0,
                            transmissionType = "Automatic",
                            yearRealse = 2023
                        },
                        new
                        {
                            Id = 4,
                            bodyType = "Coupe",
                            brand = "BMW",
                            color = "White",
                            count = 3,
                            driveType = "RWD",
                            firm = "BMW",
                            fuelType = "Gasoline",
                            model = "M4",
                            price = 70000.0,
                            transmissionType = "Manual",
                            yearRealse = 2023
                        },
                        new
                        {
                            Id = 5,
                            bodyType = "Hatchback",
                            brand = "Volkswagen",
                            color = "Green",
                            count = 8,
                            driveType = "FWD",
                            firm = "Volkswagen",
                            fuelType = "Gasoline",
                            model = "Golf",
                            price = 25000.0,
                            transmissionType = "Automatic",
                            yearRealse = 2023
                        });
                });

            modelBuilder.Entity("Car_oop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMetgodId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("ClientId");

                    b.HasIndex("PaymentMetgodId")
                        .IsUnique();

                    b.HasIndex("PersonId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            ClientId = 1,
                            PaymentMetgodId = 1,
                            PersonId = 1,
                            orderDate = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 30000.0,
                            status = "Completed"
                        },
                        new
                        {
                            Id = 2,
                            CarId = 2,
                            ClientId = 2,
                            PaymentMetgodId = 2,
                            PersonId = 2,
                            orderDate = new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 35000.0,
                            status = "Pending"
                        },
                        new
                        {
                            Id = 3,
                            CarId = 3,
                            ClientId = 3,
                            PaymentMetgodId = 3,
                            PersonId = 3,
                            orderDate = new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 45000.0,
                            status = "Completed"
                        },
                        new
                        {
                            Id = 4,
                            CarId = 4,
                            ClientId = 4,
                            PaymentMetgodId = 4,
                            PersonId = 4,
                            orderDate = new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 70000.0,
                            status = "Pending"
                        },
                        new
                        {
                            Id = 5,
                            CarId = 5,
                            ClientId = 5,
                            PaymentMetgodId = 5,
                            PersonId = 5,
                            orderDate = new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            price = 25000.0,
                            status = "Completed"
                        });
                });

            modelBuilder.Entity("Car_oop.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("paymentMethod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            paymentMethod = "Credit Card"
                        },
                        new
                        {
                            Id = 2,
                            paymentMethod = "Cash"
                        },
                        new
                        {
                            Id = 3,
                            paymentMethod = "Bank Transfer"
                        },
                        new
                        {
                            Id = 4,
                            paymentMethod = "Financing"
                        },
                        new
                        {
                            Id = 5,
                            paymentMethod = "Leasing"
                        });
                });

            modelBuilder.Entity("Car_oop.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("experience")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("payday")
                        .HasColumnType("double");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostId = 1,
                            experience = 5,
                            name = "Alice",
                            payday = 1000.0,
                            surname = "Johnson"
                        },
                        new
                        {
                            Id = 2,
                            PostId = 2,
                            experience = 3,
                            name = "Bob",
                            payday = 2000.0,
                            surname = "Brown"
                        },
                        new
                        {
                            Id = 3,
                            PostId = 3,
                            experience = 10,
                            name = "Charlie",
                            payday = 3000.0,
                            surname = "Davis"
                        },
                        new
                        {
                            Id = 4,
                            PostId = 4,
                            experience = 2,
                            name = "Diana",
                            payday = 4000.0,
                            surname = "Miller"
                        },
                        new
                        {
                            Id = 5,
                            PostId = 5,
                            experience = 1,
                            name = "Edward",
                            payday = 1000.0,
                            surname = "Wilson"
                        });
                });

            modelBuilder.Entity("Car_oop.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("namePost")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            namePost = "Sales Manager"
                        },
                        new
                        {
                            Id = 2,
                            namePost = "Service Technician"
                        },
                        new
                        {
                            Id = 3,
                            namePost = "Finance Manager"
                        },
                        new
                        {
                            Id = 4,
                            namePost = "Customer Service Representative"
                        },
                        new
                        {
                            Id = 5,
                            namePost = "Detailer"
                        });
                });

            modelBuilder.Entity("Car_oop.Models.Car", b =>
                {
                    b.HasOne("Car_oop.Models.ModelCar", "modelCar")
                        .WithMany("cars")
                        .HasForeignKey("ModelCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("modelCar");
                });

            modelBuilder.Entity("Car_oop.Models.Order", b =>
                {
                    b.HasOne("Car_oop.Models.Car", "car")
                        .WithOne("order")
                        .HasForeignKey("Car_oop.Models.Order", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car_oop.Models.Client", "client")
                        .WithMany("orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car_oop.Models.PaymentMethod", "paymentMethod")
                        .WithOne("order")
                        .HasForeignKey("Car_oop.Models.Order", "PaymentMetgodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Car_oop.Models.Person", "person")
                        .WithMany("orders")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");

                    b.Navigation("client");

                    b.Navigation("paymentMethod");

                    b.Navigation("person");
                });

            modelBuilder.Entity("Car_oop.Models.Person", b =>
                {
                    b.HasOne("Car_oop.Models.Post", "post")
                        .WithMany("person")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");
                });

            modelBuilder.Entity("Car_oop.Models.Car", b =>
                {
                    b.Navigation("order")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_oop.Models.Client", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Car_oop.Models.ModelCar", b =>
                {
                    b.Navigation("cars");
                });

            modelBuilder.Entity("Car_oop.Models.PaymentMethod", b =>
                {
                    b.Navigation("order")
                        .IsRequired();
                });

            modelBuilder.Entity("Car_oop.Models.Person", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("Car_oop.Models.Post", b =>
                {
                    b.Navigation("person");
                });
#pragma warning restore 612, 618
        }
    }
}
