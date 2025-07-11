
using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using System.Globalization;
using EshopApp.Application.DTO;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for retrieving all products, including their categories, from the system.
    /// </summary>
    public class GetProductsUseCase
    {
        /// <summary>
        /// The repository for accessing product data.
        /// </summary>
        private readonly IProductRepository _ProductRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductsUseCase"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository dependency.</param>
        public GetProductsUseCase(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }

        /// <summary>
        /// Retrieves all products from the repository, including their categories, and maps them to DTOs.
        /// </summary>
        /// <returns>A collection of <see cref="ProductDTO"/> objects representing all products.</returns>
        public async Task<IEnumerable<ProductDTO>> ExecuteAsync()
        {
            // Fetch all products from the repository
            var products = await _ProductRepository.GetAllProductsAsync();

            // Map each product and its category to DTOs
            return products.Select(pro => new ProductDTO
            {
                Name = pro.Name,
                Id = pro.Id,
                Price = pro.Price,
                Description = pro.Description,
                Category = pro.Category == null ? null : new CategoryDTO
                {
                    Name = pro.Category.Name,
                    Id = pro.Category.CategoryId ?? Guid.Empty,
                    ImageUrl = pro.Category.ImageUrl,
                    DisplayOrder = pro.Category.DisplayOrder,
                    ParentId = pro.Category.ParentId,
                }
            });
        }
    }
}