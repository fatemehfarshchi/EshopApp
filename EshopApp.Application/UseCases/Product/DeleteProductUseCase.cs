using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for deleting a product from the system.
    /// </summary>
    public class DeleteProductUseCase
    {
        /// <summary>
        /// The repository for accessing and deleting product data.
        /// </summary>
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProductUseCase"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository dependency.</param>
        public DeleteProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Deletes the product with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        public async Task ExecuteAsync(Guid id)
        {
            // Delete the product by ID
            await _productRepository.DeleteAsync(id);
        }
    }
}
