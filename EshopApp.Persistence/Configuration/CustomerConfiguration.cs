using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EshopApp.Persistence.Configurations
{
    /// <summary>
    /// Entity Framework configuration for the <see cref="Customer"/> entity.
    /// Defines table mapping, property constraints, and owned address configuration for customers.
    /// </summary>
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Configures the <see cref="Customer"/> entity's schema and owned address value object.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Set primary key
            builder.HasKey(c => c.Id);

            // Configure Name property with max length and required constraint
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Configure owned Address value object
            builder.OwnsOne(c => c.Address, address =>
            {
                address.Property(a => a.City)
                       .HasColumnName("City")
                       .HasMaxLength(100);

                address.Property(a => a.Street)
                       .HasColumnName("Street")
                       .HasMaxLength(200);

                address.Property(a => a.PostalCode)
                       .HasColumnName("PostalCode")
                       .HasMaxLength(20);

                // Redundant configuration for Address properties (can be removed if not needed)
                builder.OwnsOne(c => c.Address, address =>
                {
                    address.Property(a => a.City).HasMaxLength(100);
                    address.Property(a => a.Street).HasMaxLength(200);
                    address.Property(a => a.PostalCode).HasMaxLength(20);
                });
            });
        }
    }
}
