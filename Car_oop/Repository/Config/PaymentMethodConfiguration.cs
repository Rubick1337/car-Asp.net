using Car_oop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.HasData(
            new PaymentMethod { Id = 1, paymentMethod = "Credit Card" },
            new PaymentMethod { Id = 2, paymentMethod = "Cash" },
            new PaymentMethod { Id = 3, paymentMethod = "Bank Transfer" },
            new PaymentMethod { Id = 4, paymentMethod = "Financing" },
            new PaymentMethod { Id = 5, paymentMethod = "Leasing" }
        );

    }
}