using EshopApp.Domain.Enums;

namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for updating an existing invoice.
    /// </summary>
    public class UpdateInvoiceDto
    {
        /// <summary>
        /// The unique identifier of the invoice to update.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique identifier of the customer for the invoice.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The updated date of the invoice.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The updated payment method for the invoice.
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// The updated status of the invoice.
        /// </summary>
        public InvoiceStatus Status { get; set; }

        /// <summary>
        /// The list of updated invoice items.
        /// </summary>
        public List<UpdateInvoiceItemDto> Items { get; set; } = new();
    }
}
