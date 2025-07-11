using System.Collections.Generic;
using System.Threading.Tasks;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing product entities in the data store.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Updates the stock quantity for a product after a sale.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="quantitysold">The quantity sold to subtract from stock.</param>
        Task UpdateStockAsync(Guid productId, int quantitysold);

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product entity if found; otherwise, null.</returns>
        Task<Product?> GetByIdAsync(Guid id);

        /// <summary>
        /// Adds a new product to the data store.
        /// </summary>
        /// <param name="product">The product entity to add.</param>
        Task AddAsync(Product product);

        /// <summary>
        /// Checks if a product exists by its name.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <returns>True if the product exists; otherwise, false.</returns>
        Task<bool> ExistsByNameAsync(string name);

        /// <summary>
        /// Retrieves all products from the data store.
        /// </summary>
        /// <returns>An enumerable of all product entities.</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync();

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Updates an existing product in the data store.
        /// </summary>
        /// <param name="product">The product entity with updated data.</param>
        Task UpdateAsync(Product product);

        /// <summary>
        /// Assigns a product to a category.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="categoryId">The unique identifier of the category.</param>
        Task AssignCategoryAsync(Guid productId, Guid categoryId);
    }
}