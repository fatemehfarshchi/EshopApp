namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a new product.
    /// </summary>
    public class CreateProductDTO
    {
        /// <summary>
        /// The name of the product to create.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The quantity of the product in stock.
        /// </summary>
        public int QuantityInStock { get; set; }

        /// <summary>
        /// The unique identifier of the category the product belongs to.
        /// </summary>
        public Guid CategoryID { get; set; }

        /// <summary>
        /// The description of the product (optional).
        /// </summary>
        public string? Description { get; set; }
    }
}
