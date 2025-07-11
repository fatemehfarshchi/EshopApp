using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EshopApp.Persistence;
using System;




namespace EshopApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for managing product entities in the database.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// The application's database context.
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product if found; otherwise, null.</returns>
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        /// <summary>
        /// Updates the stock of a product by decreasing it by the quantity sold.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="quantitySold">The quantity sold to decrease from stock.</param>
        public async Task UpdateStockAsync(Guid productId, int quantitySold)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                throw new Exception("product not find!");
            }
            product.DecreaseStock(quantitySold);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a new product to the database and saves changes.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if a product with the specified name exists in the database.
        /// </summary>
        /// <param name="name">The name of the product to check.</param>
        /// <returns>True if a product with the name exists; otherwise, false.</returns>
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Products.AnyAsync(c => c.Name == name);
        }

        /// <summary>
        /// Retrieves all products, including their categories, from the database.
        /// </summary>
        /// <returns>A collection of all products.</returns>
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                                 .Include(c => c.Category)
                                 .ToListAsync();
        }

        /// <summary>
        /// Deletes a product from the database by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("product not find");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing product in the database and saves changes.
        /// </summary>
        /// <param name="product">The product to update.</param>
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Assigns a category to a product and saves changes.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="categoryId">The unique identifier of the category to assign.</param>
        public async Task AssignCategoryAsync(Guid productId, Guid categoryId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new InvalidOperationException("Product not found");
            product.CategoryID = categoryId;
            await _context.SaveChangesAsync();
        }
    }
}