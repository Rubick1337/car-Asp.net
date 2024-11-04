using Car_oop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(
            new Car { Id = 1, ModelCarId = 1 },
            new Car { Id = 2, ModelCarId = 2 },
            new Car { Id = 3, ModelCarId = 3 },
            new Car { Id = 4, ModelCarId = 4 },
            new Car { Id = 5, ModelCarId = 5 }
        );
    }
}