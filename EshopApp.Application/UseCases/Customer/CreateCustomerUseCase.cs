
using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using System.Globalization;
using EshopApp.Application.DTO;
using EshopApp.Domain.ValueObjects;
using EshopApp.Shared;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for creating a new customer in the system.
    /// </summary>
    public class CreateCustomerUseCase
    {
        /// <summary>
        /// The repository for accessing and adding customer data.
        /// </summary>
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerUseCase"/> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository dependency.</param>
        public CreateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Creates a new customer using the provided DTO.
        /// </summary>
        /// <param name="dto">The DTO containing customer information.</param>
        /// <exception cref="ArgumentException">Thrown if the customer name is null or empty.</exception>
        /// <exception cref="Exception">Thrown if a customer with the same name already exists.</exception>
        public async Task ExecuteAsync(CreateCustomerDTO dto)
        {
            // Validate that the customer name is not null or empty
            if (dto.Name.IsNullOrEmpty())
                throw new ArgumentException("Name can not be NULL.");

            // Check if a customer with the same name already exists
            var exists = await _customerRepository.ExistsByNameAsync(dto.Name);

            if (exists)
            {
                throw new Exception("Customer already exists");
            }

            // Create the address value object
            var address = new Address(dto.City, dto.Street, dto.PostalCode);

            // Create the customer entity
            var customer = new Customer(dto.Name, address);

            // Add the new customer to the repository
            await _customerRepository.AddAsync(customer);
        }
    }
}