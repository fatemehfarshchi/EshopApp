using System.Collections.Generic;
using System.Threading.Tasks;
using EshopApp.Application.DTOs;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces
{
    /// <summary>
    /// Repository interface for managing invoice entities in the data store.
    /// </summary>
    public interface IInvoiceRepository
    {
        /// <summary>
        /// Retrieves all invoices from the data store.
        /// </summary>
        /// <returns>An enumerable of all invoice entities.</returns>
        Task<IEnumerable<Invoice>> GetAllInvoicesAsync();

        /// <summary>
        /// Adds a new invoice to the data store.
        /// </summary>
        /// <param name="invoice">The invoice entity to add.</param>
        Task AddAsync(Invoice invoice);

        /// <summary>
        /// Deletes an invoice by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice to delete.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Updates an existing invoice in the data store.
        /// </summary>
        /// <param name="invoice">The invoice entity with updated data.</param>
        Task UpdateAsync(Invoice invoice);

        /// <summary>
        /// Retrieves an invoice by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice.</param>
        /// <returns>The invoice entity if found; otherwise, null.</returns>
        Task<Invoice?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves invoices filtered by customer and date range.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer (optional).</param>
        /// <param name="fromDate">The start date for filtering (optional).</param>
        /// <param name="toDate">The end date for filtering (optional).</param>
        /// <returns>List of filtered invoice entities.</returns>
        Task<List<Invoice>> GetFilteredAsync(Guid? customerId, DateTime? fromDate, DateTime? toDate);

        /// <summary>
        /// Retrieves the total invoice summary for a customer.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>The total invoice summary DTO for the customer, or null if not found.</returns>
        Task<CustomerTotalInvoiceDto?> GetCustomerTotalInvoiceAsync(Guid customerId);
    }
}