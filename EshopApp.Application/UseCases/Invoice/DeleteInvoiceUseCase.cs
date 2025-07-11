using System.ComponentModel;
using System.Net;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Enums;
using EshopApp.Shared.Constants;


namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for deleting an invoice from the system. Sets the invoice status to Canceled before deletion.
    /// </summary>
    public class DeleteInvoiceUseCase
    {
        /// <summary>
        /// The repository for accessing and deleting invoice data.
        /// </summary>
        private readonly IInvoiceRepository _invoiceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteInvoiceUseCase"/> class.
        /// </summary>
        /// <param name="invoiceRepository">The invoice repository dependency.</param>
        public DeleteInvoiceUseCase(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        /// <summary>
        /// Deletes the invoice with the specified ID after setting its status to Canceled.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice to delete.</param>
        /// <exception cref="Exception">Thrown if the invoice is not found.</exception>
        public async Task ExecuteAsync(Guid id)
        {
            // Retrieve the invoice by ID
            var invoice = await _invoiceRepository.GetByIdAsync(id);

            if (invoice == null)
                throw new Exception(AppConstants.ErrorMessages.InvoiceNotFound);

            // Set the invoice status to Canceled before deletion
            invoice.Status = InvoiceStatus.Canceled;
            
            // Delete the invoice
            await _invoiceRepository.DeleteAsync(id);
        }
    }
}
