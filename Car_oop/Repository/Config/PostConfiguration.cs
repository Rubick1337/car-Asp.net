using Car_oop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasData(
            new Post { Id = 1, namePost = "Sales Manager" },
            new Post { Id = 2, namePost = "Service Technician" },
            new Post { Id = 3, namePost = "Finance Manager" },
            new Post { Id = 4, namePost = "Customer Service Representative" },
            new Post { Id = 5, namePost = "Detailer" }
        );

    }
}