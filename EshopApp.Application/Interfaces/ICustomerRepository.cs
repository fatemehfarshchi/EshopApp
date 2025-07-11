using System.Collections.Generic;
using System.Threading.Tasks;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing customer entities in the data store.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Retrieves a customer by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>The customer entity if found; otherwise, null.</returns>
        Task<Customer?> GetByIdAsync(Guid id);

        /// <summary>
        /// Adds a new customer to the data store.
        /// </summary>
        /// <param name="customer">The customer entity to add.</param>
        Task AddAsync(Customer customer);

        /// <summary>
        /// Checks if a customer exists by its name.
        /// </summary>
        /// <param name="name">The name of the customer.</param>
        /// <returns>True if the customer exists; otherwise, false.</returns>
        Task<bool> ExistsByNameAsync(string name);

        /// <summary>
        /// Retrieves all customers from the data store.
        /// </summary>
        /// <returns>An enumerable of all customer entities.</returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// Deletes a customer by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to delete.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Updates an existing customer in the data store.
        /// </summary>
        /// <param name="customer">The customer entity with updated data.</param>
        Task UpdateAsync(Customer customer);
    }
}