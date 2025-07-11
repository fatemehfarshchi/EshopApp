using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for deleting an invoice item from the system.
    /// </summary>
    public class DeleteInvoiceItemUseCase
    {
        /// <summary>
        /// The repository for accessing and deleting invoice item data.
        /// </summary>
        private readonly IInvoiceItemRepository _invoiceitemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteInvoiceItemUseCase"/> class.
        /// </summary>
        /// <param name="invoiceitemRepository">The invoice item repository dependency.</param>
        public DeleteInvoiceItemUseCase(IInvoiceItemRepository invoiceitemRepository)
        {
            _invoiceitemRepository = invoiceitemRepository;
        }

        /// <summary>
        /// Deletes the invoice item with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice item to delete.</param>
        public async Task ExecuteAsync(Guid id)
        {
            // Delete the invoice item by ID
            await _invoiceitemRepository.DeleteAsync(id);
        }
    }
}
