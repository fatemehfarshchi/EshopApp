
using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using System.Globalization;
using EshopApp.Application.DTO;

namespace EshopApp.Application.UseCase
{
    /// <summary>
    /// Use case for retrieving all invoices, including their items, from the system.
    /// </summary>
    public class GetInvoicesUseCase
    {
        /// <summary>
        /// The repository for accessing invoice data.
        /// </summary>
        private readonly IInvoiceRepository _InvoiceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoicesUseCase"/> class.
        /// </summary>
        /// <param name="invoiceRepository">The invoice repository dependency.</param>
        public GetInvoicesUseCase(IInvoiceRepository invoiceRepository)
        {
            _InvoiceRepository = invoiceRepository;
        }

        /// <summary>
        /// Retrieves all invoices from the repository, including their items, and maps them to DTOs.
        /// </summary>
        /// <returns>A collection of <see cref="InvoiceDTO"/> objects representing all invoices.</returns>
        public async Task<IEnumerable<InvoiceDTO>> ExecuteAsync()
        {
            // Fetch all invoices from the repository
            var invoices = await _InvoiceRepository.GetAllInvoicesAsync();

            // Map each invoice and its items to DTOs
            return invoices.Select(inv => new InvoiceDTO
            {
                Id = inv.Id,
                Date = inv.Date,
                PaymentMethod = inv.PaymentMethod,
                Status = inv.Status,
                Items = inv.Items.Select(i => new InvoiceItemDTO
                {
                    Quantity = i.Quantity,
                    Id = i.Id,
                    UnitPrice = i.UnitPrice,
                    ProductName = i.ProductName
                }).ToList()
            });
        }
    }
}