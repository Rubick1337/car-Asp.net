using Car_oop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasData(
            new Order { Id = 1, orderDate = new DateTime(2023, 11, 1), price = 30000, status = "Completed", PersonId = 1, CarId = 1, ClientId = 1, PaymentMetgodId = 1 },
            new Order { Id = 2, orderDate = new DateTime(2023, 11, 2), price = 35000, status = "Pending", PersonId = 2, CarId = 2, ClientId = 2, PaymentMetgodId = 2 },
            new Order { Id = 3, orderDate = new DateTime(2023, 11, 3), price = 45000, status = "Completed", PersonId = 3, CarId = 3, ClientId = 3, PaymentMetgodId = 3 },
            new Order { Id = 4, orderDate = new DateTime(2023, 11, 4), price = 70000, status = "Pending", PersonId = 4, CarId = 4, ClientId = 4, PaymentMetgodId = 4 },
            new Order { Id = 5, orderDate = new DateTime(2023, 11, 5), price = 25000, status = "Completed", PersonId = 5, CarId = 5, ClientId = 5, PaymentMetgodId = 5 }
        );

    }
}