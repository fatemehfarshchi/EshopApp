using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EshopApp.Domain.Entities;

namespace EshopApp.Persistence.Configuration;

/// <summary>
/// Entity Framework configuration for the <see cref="Product"/> entity.
/// Defines table mapping, property constraints, and default values for products.
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    /// Configures the <see cref="Product"/> entity's schema and property constraints.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Set primary key
        builder.HasKey(p => p.Id);

        // Configure Id with default value (NEWID())
        builder.Property(p => p.Id)
                .HasDefaultValueSql("NEWID()");

        // Configure Price with decimal type
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

        // Configure Name with max length and required
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        // Configure Description with max length
        builder.Property(p => p.Description).HasMaxLength(500);
    }
}
