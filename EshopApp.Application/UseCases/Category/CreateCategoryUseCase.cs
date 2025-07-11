
using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using System.Globalization;
using EshopApp.Application.DTO;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for creating a new category.
    /// Checks for duplicate category names and adds the category if it does not exist.
    /// </summary>
    public class CreateCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Constructor that injects the category repository dependency.
        /// </summary>
        /// <param name="categoryRepository">The repository for category data.</param>
        public CreateCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Executes the creation of a new category.
        /// </summary>
        /// <param name="dto">The DTO containing category data to create.</param>
        /// <exception cref="Exception">Thrown if a category with the same name already exists.</exception>
        public async Task ExecuteAsync(CreateCategoryDTO dto)
        {
            // Check if a category with the same name already exists
            var exists = await _categoryRepository.ExistsByNameAsync(dto.Name);

            if (exists)
            {
                throw new Exception("Category already exists");
            }

            // Create a new category entity and add it to the repository
            var category = new Category(dto.Name, dto.ParentId, dto.ImageUrl, dto.DisplayOrder);
            await _categoryRepository.AddAsync(category);
        }
    }
}