namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a new invoice item.
    /// </summary>
    public class CreateInvoiceItemDTO
    {
        /// <summary>
        /// The quantity of the product in the invoice item.
        /// </summary>
        public int Quantity { set; get; }

        /// <summary>
        /// The unit price of the product in the invoice item.
        /// </summary>
        public decimal UnitPrice { set; get; }

        /// <summary>
        /// The unique identifier of the product for the invoice item.
        /// </summary>
        public Guid ProductId { set; get; }
    }
}
