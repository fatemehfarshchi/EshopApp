using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EshopApp.Persistence;
using System;



namespace EshopApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for managing category entities in the database.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        /// <summary>
        /// The application's database context.
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The category if found; otherwise, null.</returns>
        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        /// <summary>
        /// Adds a new category to the database and saves changes.
        /// </summary>
        /// <param name="category">The category to add.</param>
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if a category with the specified name exists in the database.
        /// </summary>
        /// <param name="name">The name of the category to check.</param>
        /// <returns>True if a category with the name exists; otherwise, false.</returns>
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name);
        }

        /// <summary>
        /// Retrieves all categories, including their children and parent, from the database.
        /// </summary>
        /// <returns>A collection of all categories.</returns>
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                                 .Include(c => c.Children)
                                 .Include(c => c.Parent)
                                 .ToListAsync();
        }

        /// <summary>
        /// Deletes a category and its children from the database by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories
                .Include(c => c.Children)
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            if (category != null)
            {
                _context.Categories.RemoveRange(category.Children);
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates an existing category in the database and saves changes.
        /// </summary>
        /// <param name="category">The category to update.</param>
        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}