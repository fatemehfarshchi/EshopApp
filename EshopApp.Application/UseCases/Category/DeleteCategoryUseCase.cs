using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for deleting a category by its unique identifier.
    /// </summary>
    public class DeleteCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Constructor that injects the category repository dependency.
        /// </summary>
        /// <param name="categoryRepository">The repository for category data.</param>
        public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Executes the deletion of a category.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        public async Task ExecuteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }
    }
}
