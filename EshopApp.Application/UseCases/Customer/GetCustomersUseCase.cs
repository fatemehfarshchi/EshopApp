
using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using System.Globalization;
using EshopApp.Application.DTO;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for retrieving all customers, including their products and product categories.
    /// </summary>
    public class GetCustomersUseCase
    {
        /// <summary>
        /// The repository for accessing customer data.
        /// </summary>
        private readonly ICustomerRepository _CustomerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCustomersUseCase"/> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository dependency.</param>
        public GetCustomersUseCase(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }

        /// <summary>
        /// Retrieves all customers from the repository, including their products and product categories, and maps them to DTOs.
        /// </summary>
        /// <returns>A collection of <see cref="CustomerDTO"/> objects representing all customers.</returns>
        public async Task<IEnumerable<CustomerDTO>> ExecuteAsync()
        {
            // Fetch all customers from the repository
            var customers = await _CustomerRepository.GetAllCustomersAsync();

            // Map each customer and their products (with categories) to DTOs
            return customers.Select(cus => new CustomerDTO
            {
                Id = cus.Id,
                Name = cus.Name,
                Product = cus.Products.Select(i => new ProductDTO
                {
                    Name = i.Name,
                    Price = i.Price,
                    Category = i.Category == null ? null : new CategoryDTO
                    {
                        Name = i.Category.Name,
                        Id = i.Category.CategoryId ?? Guid.Empty,
                        ImageUrl = i.Category.ImageUrl,
                        DisplayOrder = i.Category.DisplayOrder,
                        ParentId = i.Category.ParentId,
                    }
                }).ToList()
            });
        }
    }
}