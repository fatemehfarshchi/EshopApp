using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EshopApp.Domain.Entities;

namespace EshopApp.Persistence.Configuration;

/// <summary>
/// Entity Framework configuration for the <see cref="User"/> entity.
/// Defines table mapping, property constraints, and default values for users.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// Configures the <see cref="User"/> entity's schema and property constraints.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Set primary key
        builder.HasKey(u => u.Id);

        // Configure Name with max length and required
        builder.Property(u => u.Name)
               .IsRequired()
               .HasMaxLength(100);

        // Configure UserName with max length and required
        builder.Property(u => u.UserName)
               .IsRequired()
               .HasMaxLength(50);

        // Configure Email with max length and required
        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(100);

        // Configure PasswordHash as required
        builder.Property(u => u.PasswordHash)
               .IsRequired();

        // Configure Role with max length, required, and default value
        builder.Property(u => u.Role)
               .IsRequired()
               .HasMaxLength(20)
               .HasDefaultValue("Seller");

        // Configure DateCreated with default value (UTC now)
        builder.Property(u => u.DateCreated)
               .HasDefaultValueSql("GETUTCDATE()");

        // Map to Users table
        builder.ToTable("Users");
    }
}
