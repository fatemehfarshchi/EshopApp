using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for deleting a customer from the system.
    /// </summary>
    public class DeleteCustomerUseCase
    {
        /// <summary>
        /// The repository for accessing and deleting customer data.
        /// </summary>
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCustomerUseCase"/> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository dependency.</param>
        public DeleteCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Deletes the customer with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to delete.</param>
        public async Task ExecuteAsync(Guid id)
        {
            // Delete the customer by ID
            await _customerRepository.DeleteAsync(id);
        }
    }
}
