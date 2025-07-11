using EshopApp.Application.DTO;
using EshopApp.Domain.Enums;

namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) representing an invoice and its details.
    /// </summary>
    public class InvoiceDTO
    {
        /// <summary>
        /// The unique identifier of the invoice.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The name of the customer for the invoice.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// The date of the invoice.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The payment method used for the invoice.
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;

        /// <summary>
        /// The status of the invoice.
        /// </summary>
        public InvoiceStatus Status { get; set; }

        /// <summary>
        /// The collection of items included in the invoice.
        /// </summary>
        public IReadOnlyCollection<InvoiceItemDTO> Items { get; set; } = new List<InvoiceItemDTO>();
    }
}
