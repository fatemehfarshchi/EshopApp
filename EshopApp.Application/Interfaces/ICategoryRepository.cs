using System.Collections.Generic;
using System.Threading.Tasks;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing category entities in the data store.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Retrieves a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The category entity if found; otherwise, null.</returns>
        Task<Category?> GetByIdAsync(Guid id);

        /// <summary>
        /// Adds a new category to the data store.
        /// </summary>
        /// <param name="category">The category entity to add.</param>
        Task AddAsync(Category category);

        /// <summary>
        /// Checks if a category exists by its name.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <returns>True if the category exists; otherwise, false.</returns>
        Task<bool> ExistsByNameAsync(string name);

        /// <summary>
        /// Retrieves all categories from the data store.
        /// </summary>
        /// <returns>An enumerable of all category entities.</returns>
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        /// <summary>
        /// Deletes a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Updates an existing category in the data store.
        /// </summary>
        /// <param name="category">The category entity with updated data.</param>
        Task UpdateAsync(Category category);
    }
}