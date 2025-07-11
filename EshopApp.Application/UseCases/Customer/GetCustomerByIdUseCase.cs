using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for retrieving a customer by their unique identifier.
    /// </summary>
    public class GetCustomerByIdUseCase
    {
        /// <summary>
        /// The repository for accessing customer data.
        /// </summary>
        private readonly ICustomerRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCustomerByIdUseCase"/> class.
        /// </summary>
        /// <param name="repository">The customer repository dependency.</param>
        public GetCustomerByIdUseCase(ICustomerRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a customer by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>The <see cref="Customer"/> entity if found; otherwise, null.</returns>
        public async Task<Customer?> ExecuteAsync(Guid id)
        {
            // Retrieve the customer by ID
            return await _repository.GetByIdAsync(id);
        }
    }
}
