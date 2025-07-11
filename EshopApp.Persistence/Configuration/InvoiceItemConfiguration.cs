using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EshopApp.Domain.Entities;

namespace EshopApp.Persistence.Configuration;

/// <summary>
/// Entity Framework configuration for the <see cref="InvoiceItem"/> entity.
/// Defines table mapping, property constraints, and relationships for invoice items.
/// </summary>
public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    /// <summary>
    /// Configures the <see cref="InvoiceItem"/> entity's schema and relationships.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        // Set primary key
        builder.HasKey(ii => ii.Id);

        // Configure InvoiceId as required
        builder.Property(ii => ii.InvoiceId)
               .IsRequired();

        // Configure ProductId as required
        builder.Property(ii => ii.ProductId)
               .IsRequired();

        // Configure Quantity as required
        builder.Property(ii => ii.Quantity)
               .IsRequired();

        // Configure UnitPrice with decimal type and required
        builder.Property(ii => ii.UnitPrice)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        // Configure ProductName with max length and required
        builder.Property(ii => ii.ProductName)
               .HasMaxLength(100)
               .IsRequired();

        // Configure relationship to Invoice with cascade delete
        builder.HasOne(ii => ii.Invoice)
               .WithMany(i => i.Items)
               .HasForeignKey(ii => ii.InvoiceId)
               .OnDelete(DeleteBehavior.Cascade);

        // Map to InvoiceItems table
        builder.ToTable("InvoiceItems");
    }
}
