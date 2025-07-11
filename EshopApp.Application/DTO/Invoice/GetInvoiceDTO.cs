using EshopApp.Domain.Enums;

namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for retrieving invoice details.
    /// </summary>
    public class GetInvoiceDTO
    {
        /// <summary>
        /// The unique identifier of the invoice.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The date the invoice was issued.
        /// </summary>
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// The name of the customer for the invoice.
        /// </summary>
        public string CustomerName { get; set; } = "";

        /// <summary>
        /// The list of items included in the invoice.
        /// </summary>
        public List<GetInvoiceItemDTO> Items { get; set; } = new();

        /// <summary>
        /// The total amount of the invoice.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// The payment method used for the invoice.
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// The status of the invoice.
        /// </summary>
        public InvoiceStatus Status { get; set; }
    }
}
