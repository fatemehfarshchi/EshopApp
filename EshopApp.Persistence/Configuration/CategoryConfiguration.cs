using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EshopApp.Domain.Entities;

namespace EshopApp.Persistence.Configuration;

/// <summary>
/// Entity Framework configuration for the <see cref="Category"/> entity.
/// Defines table mapping, property constraints, and relationships for categories.
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    /// <summary>
    /// Configures the <see cref="Category"/> entity's schema and relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Set primary key
        builder.HasKey(c => c.CategoryId);

        // Configure CategoryId as required
        builder.Property(c => c.CategoryId)
            .IsRequired();

        // Configure Name property with max length and required constraint
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        // Configure ImageUrl property with max length
        builder.Property(c => c.ImageUrl)
            .HasMaxLength(200);

        // Configure DisplayOrder as required
        builder.Property(c => c.DisplayOrder)
            .IsRequired();

        // Configure self-referencing parent-child relationship
        builder.HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Map to Categories table
        builder.ToTable("Categories");
    }
}
