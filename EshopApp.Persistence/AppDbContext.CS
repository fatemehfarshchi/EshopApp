using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EshopApp.Persistence.Configurations;

namespace EshopApp.Persistence
{
    /// <summary>
    /// The application's Entity Framework database context.
    /// Manages entity sets, relationships, and configuration for the EshopApp database.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the invoices in the database.
        /// </summary>
        public DbSet<Invoice> Invoices { get; set; }
        /// <summary>
        /// Gets or sets the invoice items in the database.
        /// </summary>
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        /// <summary>
        /// Gets or sets the categories in the database.
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Gets or sets the customers in the database.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Gets or sets the products in the database.
        /// </summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// Gets or sets the users in the database.
        /// </summary>
        public DbSet<User> Users{ get; set; }
        /// <summary>
        /// Gets or sets the store information in the database.
        /// </summary>
        public DbSet<StoreInfo> StoreInfos { get; set; }

        /// <summary>
        /// Configures the entity model and relationships for the application's database schema.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the entity model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Invoice-Items relationship
            modelBuilder.Entity<Invoice>()
            .HasMany(i => i.Items)
            .WithOne()
            .HasForeignKey(i => i.InvoiceId)
            .OnDelete(DeleteBehavior.NoAction);

            // Configure Category-Children relationship
            modelBuilder.Entity<Category>()
            .HasMany(c => c.Children)
            .WithOne(c => c.Parent)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

            // Configure Product-Category relationship
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryID)
            .OnDelete(DeleteBehavior.NoAction);

            // Configure InvoiceItem-Invoice relationship
            modelBuilder.Entity<InvoiceItem>()
            .HasOne(ii => ii.Invoice)
            .WithMany(i => i.Items)
            .HasForeignKey(ii => ii.InvoiceId)
            .OnDelete(DeleteBehavior.NoAction);

            // Configure Product Id as value generated on add
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();

            // Apply additional entity configurations
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        }
    }
}