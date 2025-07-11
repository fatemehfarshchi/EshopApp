using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EshopApp.Domain.Entities;

namespace EshopApp.Persistence.Configuration;

/// <summary>
/// Entity Framework configuration for the <see cref="StoreInfo"/> entity.
/// Defines table mapping and property constraints for store information.
/// </summary>
public class StoreInfoConfiguration : IEntityTypeConfiguration<StoreInfo>
{
    /// <summary>
    /// Configures the <see cref="StoreInfo"/> entity's schema and property constraints.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<StoreInfo> builder)
    {
        // Set primary key
        builder.HasKey(s => s.Id);

        // Configure Name with max length and required
        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(100);

        // Configure Address with max length and required
        builder.Property(s => s.Address)
               .IsRequired()
               .HasMaxLength(200);

        // Configure Phone with max length and required
        builder.Property(s => s.Phone)
               .IsRequired()
               .HasMaxLength(20);

        // Configure Website with max length
        builder.Property(s => s.Website)
               .HasMaxLength(100);

        // Map to StoreInfos table
        builder.ToTable("StoreInfos");
    }
}
