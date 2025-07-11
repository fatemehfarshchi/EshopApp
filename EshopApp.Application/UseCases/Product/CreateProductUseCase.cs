
using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using System.Globalization;
using EshopApp.Application.DTO;
using EshopApp.Shared;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for creating a new product in the system.
    /// </summary>
    public class CreateProductUseCase
    {
        /// <summary>
        /// The unit of work for accessing repositories and managing transactions.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductUseCase"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work dependency.</param>
        public CreateProductUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a new product using the provided DTO.
        /// </summary>
        /// <param name="dto">The DTO containing product information.</param>
        /// <returns>The unique identifier of the newly created product.</returns>
        /// <exception cref="Exception">Thrown if a product with the same name already exists.</exception>
        public async Task<Guid> ExecuteAsync(CreateProductDTO dto)
        {
            Guid categoryId = dto.CategoryID;
            // Check if a product with the same name already exists
            var exists = await _unitOfWork.ExistsByNameAsync(dto.Name);

            if (exists)
            {
                throw new Exception("Product already exists");
            }

            // Create the product entity
            var product = new Product(dto.Name, dto.UnitPrice, dto.QuantityInStock, dto.CategoryID, dto.Description ?? "")
            {
                Id = Guid.NewGuid()
            };

            // Add the new product to the repository
            await _unitOfWork.ProductRepository.AddAsync(product);
            Console.WriteLine(product.Id);
            return product.Id;
        }
    }
}