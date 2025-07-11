using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;




namespace EshopApp.Persistence
{
    /// <summary>
    /// Factory for creating <see cref="AppDbContext"/> instances at design time (e.g., for migrations).
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <summary>
        /// Creates a new <see cref="AppDbContext"/> instance using the connection string from appsettings.json.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        /// <returns>A configured <see cref="AppDbContext"/> instance.</returns>
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Build configuration from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") 
                .Build();

            // Get connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure SQL Server provider
            optionsBuilder.UseSqlServer(connectionString);

            // Return configured context
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
