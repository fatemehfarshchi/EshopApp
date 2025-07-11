using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for retrieving a product by its unique identifier.
    /// </summary>
    public class GetProductByIdUseCase
    {
        /// <summary>
        /// The repository for accessing product data.
        /// </summary>
        private readonly IProductRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductByIdUseCase"/> class.
        /// </summary>
        /// <param name="repository">The product repository dependency.</param>
        public GetProductByIdUseCase(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The <see cref="Product"/> entity if found; otherwise, null.</returns>
        public async Task<Product?> ExecuteAsync(Guid id)
        {
            // Retrieve the product by ID
            return await _repository.GetByIdAsync(id);
        }
    }
}
