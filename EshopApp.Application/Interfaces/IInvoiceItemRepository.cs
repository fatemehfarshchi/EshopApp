using System.Collections.Generic;
using System.Threading.Tasks;
using EshopApp.Application.DTO;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces
{
    public interface IInvoiceItemRepository
    {
        Task AddRangeAsync(List<InvoiceItem> items);
        Task DeleteAsync(Guid id);
        Task<InvoiceItem?> GetByIdAsync(Guid id);
        Task UpdateAsync(InvoiceItem invoiceitem);
        /// <summary>
        /// Retrieves all invoice items for a specific invoice by its unique identifier.
        /// </summary>
        /// <param name="invoiceId">The unique identifier of the invoice.</param>
        /// <returns>List of invoice item DTOs for the specified invoice.</returns>
        Task<List<InvoiceItemDTO>> GetInvoiceItemsByInvoiceIdAsync(Guid invoiceId);

    }
}