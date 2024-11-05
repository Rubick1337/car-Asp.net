using Car_oop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasData(
            new Person { Id = 1, experience = 5, name = "Alice", surname = "Johnson", PostId = 1, payday = 1000 },
            new Person { Id = 2, experience = 3, name = "Bob", surname = "Brown", PostId = 2, payday = 2000 },
            new Person { Id = 3, experience = 10, name = "Charlie", surname = "Davis", PostId = 3,payday=3000 },
            new Person { Id = 4, experience = 2, name = "Diana", surname = "Miller", PostId = 4, payday = 4000 },
            new Person { Id = 5, experience = 1, name = "Edward", surname = "Wilson", PostId = 5,payday = 1000 }
        );

    }
}