using EshopApp.Application.DTO;

namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) representing a product and its details.
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// The unique identifier of the product.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The category to which the product belongs (optional).
        /// </summary>
        public CategoryDTO? Category { get; set; } = null!;

        /// <summary>
        /// The description of the product (optional).
        /// </summary>
        public string? Description { get; set; }
    }
}
