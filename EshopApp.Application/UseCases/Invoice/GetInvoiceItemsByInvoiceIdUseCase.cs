using EshopApp.Application.Interfaces;
using EshopApp.Application.DTOs;
using EshopApp.Application.DTO;

namespace EshopApp.Application.UseCase.Invoice
{
    /// <summary>
    /// Use case for retrieving invoice items by invoice ID.
    /// </summary>
    public class GetInvoiceItemsByInvoiceIdUseCase
    {
        /// <summary>
        /// The repository for accessing invoice item data.
        /// </summary>
        private readonly IInvoiceItemRepository _invoiceItemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoiceItemsByInvoiceIdUseCase"/> class.
        /// </summary>
        /// <param name="invoiceItemRepository">The invoice item repository dependency.</param>
        public GetInvoiceItemsByInvoiceIdUseCase(IInvoiceItemRepository invoiceItemRepository)
        {
            _invoiceItemRepository = invoiceItemRepository;
        }

        /// <summary>
        /// Retrieves all invoice items for a given invoice ID.
        /// </summary>
        /// <param name="invoiceId">The unique identifier of the invoice.</param>
        /// <returns>A list of <see cref="InvoiceItemDTO"/> objects for the specified invoice.</returns>
        public async Task<List<InvoiceItemDTO>> ExecuteAsync(Guid invoiceId)
        {
            // Retrieve invoice items by invoice ID
            return await _invoiceItemRepository.GetInvoiceItemsByInvoiceIdAsync(invoiceId);
        }
    }
}
