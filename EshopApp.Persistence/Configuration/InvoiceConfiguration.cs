using EshopApp.Domain.Entities;
using EshopApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EshopApp.Persistence.Configurations
{
    /// <summary>
    /// Entity Framework configuration for the <see cref="Invoice"/> entity.
    /// Defines table mapping, property constraints, and enum conversions for invoices.
    /// </summary>
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        /// <summary>
        /// Configures the <see cref="Invoice"/> entity's schema, including enum conversions.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            // Set primary key
            builder.HasKey(i => i.Id);

            // Configure PaymentMethod enum to be stored as int and required
            builder.Property(i => i.PaymentMethod)
                .HasConversion<int>()
                .IsRequired();

            // Configure Status enum to be stored as int and required
            builder.Property(i => i.Status)
                .HasConversion<int>()
                .IsRequired();
        }
    }
}
