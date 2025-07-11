
using EshopApp.Domain.Enums;

namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a new invoice.
    /// </summary>
    public class CreateInvoiceDTO
    {
        /// <summary>
        /// The unique identifier of the customer for the invoice.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The date of the invoice.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The list of items included in the invoice.
        /// </summary>
        public List<CreateInvoiceItemDTO> Items { get; set; } = new();

        /// <summary>
        /// The payment method for the invoice (default is Cash).
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash; 
    }
}


