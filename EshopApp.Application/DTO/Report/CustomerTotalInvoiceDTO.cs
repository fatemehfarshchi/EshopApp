namespace EshopApp.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) representing the total invoice summary for a customer.
    /// </summary>
    public class CustomerTotalInvoiceDto
    {
        /// <summary>
        /// The unique identifier of the customer.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// The total number of invoices for the customer.
        /// </summary>
        public int InvoiceCount { get; set; }

        /// <summary>
        /// The total amount of all invoices for the customer.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
