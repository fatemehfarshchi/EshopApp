using EshopApp.Application.Interfaces;
using EshopApp.Shared;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for assigning a category to a product in the system.
    /// </summary>
    public class AssignProductToCategoryUseCase
    {
        /// <summary>
        /// The repository for accessing and updating product data.
        /// </summary>
        private readonly IProductRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignProductToCategoryUseCase"/> class.
        /// </summary>
        /// <param name="repository">The product repository dependency.</param>
        public AssignProductToCategoryUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Assigns a category to the specified product.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="categoryId">The unique identifier of the category to assign.</param>
        /// <returns>An <see cref="OperationResult"/> indicating success or failure.</returns>
        public async Task<OperationResult> ExecuteAsync(Guid productId, Guid categoryId)
        {
            // Retrieve the product by ID
            var product = await _repository.GetByIdAsync(productId);
            if (product == null)
                return OperationResult.Fail("Product not found.");

            // Assign the category to the product
            await _repository.AssignCategoryAsync(productId, categoryId);
            return OperationResult.Ok("Category assigned to product.");
        }
    }
}
