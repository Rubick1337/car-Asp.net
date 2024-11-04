using Car_oop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasData(
            new Client { Id = 1, clientPhone = "123-456-7890", name = "John", email = "john@example.com", passport = "AB123456", surname = "Doe" },
            new Client { Id = 2, clientPhone = "987-654-3210", name = "Jane", email = "jane@example.com", passport = "CD789012", surname = "Smith" },
            new Client { Id = 3, clientPhone = "555-123-4567", name = "Michael", email = "michael@example.com", passport = "EF345678", surname = "Johnson" },
            new Client { Id = 4, clientPhone = "444-987-6543", name = "Emily", email = "emily@example.com", passport = "GH901234", surname = "Williams" },
            new Client { Id = 5, clientPhone = "333-654-7890", name = "David", email = "david@example.com", passport = "IJ567890", surname = "Brown" }
        );

    }
}