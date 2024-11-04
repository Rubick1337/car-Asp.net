using Car_oop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ModelCarConfiguration : IEntityTypeConfiguration<ModelCar>
{
    public void Configure(EntityTypeBuilder<ModelCar> builder)
    {
        builder.HasData(
            new ModelCar { Id = 1, bodyType = "Sedan", brand = "Toyota", color = "Red", count = 10, driveType = "FWD", firm = "Toyota", fuelType = "Gasoline", mileage = 0, model = "Camry", price = 30000, transmissionType = "Automatic", yearRealse = 2023 },
            new ModelCar { Id = 2, bodyType = "SUV", brand = "Honda", color = "Blue", count = 7, driveType = "AWD", firm = "Honda", fuelType = "Gasoline", mileage = 0, model = "CR-V", price = 35000, transmissionType = "Automatic", yearRealse = 2023 },
            new ModelCar { Id = 3, bodyType = "Truck", brand = "Ford", color = "Black", count = 5, driveType = "4WD", firm = "Ford", fuelType = "Diesel", mileage = 0, model = "F-150", price = 45000, transmissionType = "Automatic", yearRealse = 2023 },
            new ModelCar { Id = 4, bodyType = "Coupe", brand = "BMW", color = "White", count = 3, driveType = "RWD", firm = "BMW", fuelType = "Gasoline", mileage = 0, model = "M4", price = 70000, transmissionType = "Manual", yearRealse = 2023 },
            new ModelCar { Id = 5, bodyType = "Hatchback", brand = "Volkswagen", color = "Green", count = 8, driveType = "FWD", firm = "Volkswagen", fuelType = "Gasoline", mileage = 0, model = "Golf", price = 25000, transmissionType = "Automatic", yearRealse = 2023 }
        );

    }
}