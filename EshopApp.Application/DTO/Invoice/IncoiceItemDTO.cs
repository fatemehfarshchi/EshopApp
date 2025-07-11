namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) representing an item within an invoice.
    /// </summary>
    public class InvoiceItemDTO
    {
        /// <summary>
        /// The unique identifier of the invoice item.
        /// </summary>
        public Guid Id { set; get; }

        /// <summary>
        /// The unique identifier of the product for this invoice item.
        /// </summary>
        public Guid? ProductId { set; get; }

        /// <summary>
        /// The name of the product for this invoice item.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// The quantity of the product in this invoice item.
        /// </summary>
        public int Quantity { set; get; }

        /// <summary>
        /// The unit price of the product in this invoice item.
        /// </summary>
        public decimal UnitPrice { set; get; }

        /// <summary>
        /// The total price for this invoice item (UnitPrice * Quantity).
        /// </summary>
        public decimal Total => UnitPrice * Quantity;
    }
}
