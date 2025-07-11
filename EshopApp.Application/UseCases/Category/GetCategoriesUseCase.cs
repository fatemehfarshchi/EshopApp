
using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using System.Globalization;
using EshopApp.Application.DTO;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for retrieving all categories, including their hierarchical children.
    /// </summary>
    public class GetCategoriesUseCase
    {
        private readonly ICategoryRepository _CategoryRepository;

        /// <summary>
        /// Constructor that injects the category repository dependency.
        /// </summary>
        /// <param name="categoryRepository">The repository for category data.</param>
        public GetCategoriesUseCase(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }

        /// <summary>
        /// Executes the retrieval of all categories and their children.
        /// </summary>
        /// <returns>An enumerable of category DTOs with nested children.</returns>
        public async Task<IEnumerable<CategoryDTO>> ExecuteAsync()
        {
            // Retrieve all categories from the repository
            var categories = await _CategoryRepository.GetAllCategoriesAsync();

            // Map the category entities to DTOs, including their children
            return categories.Select(cat => new CategoryDTO
            {
                Name = cat.Name,
                Id = cat.CategoryId ?? Guid.Empty,
                ImageUrl = cat.ImageUrl,
                DisplayOrder = cat.DisplayOrder,
                ParentId = cat.ParentId,
                Children = cat.Children.Select(i => new CategoryDTO
                {
                    Name = i.Name,
                    Id = i.CategoryId ?? Guid.Empty,
                    ImageUrl = i.ImageUrl,
                    DisplayOrder = i.DisplayOrder,
                    ParentId = i.ParentId,
                }).ToList()
            });
        }
    }
}