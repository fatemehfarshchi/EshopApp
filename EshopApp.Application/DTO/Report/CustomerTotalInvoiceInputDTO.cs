namespace EshopApp.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for input when requesting a customer's total invoice summary.
    /// </summary>
    public class CustomerTotalInvoiceInputDto
    {
        /// <summary>
        /// The unique identifier of the customer for whom to calculate the total invoice summary.
        /// </summary>
        public Guid CustomerId { get; set; }
    }
}
