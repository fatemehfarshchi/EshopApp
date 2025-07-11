namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) representing a customer and their associated products.
    /// </summary>
    public class CustomerDTO
    {
        /// <summary>
        /// The unique identifier of the customer.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The list of products associated with the customer.
        /// </summary>
        public List<ProductDTO> Product = new();

        /// <summary>
        /// The city where the customer resides.
        /// </summary>
        public string City { get; set; } = "";

        /// <summary>
        /// The street address of the customer.
        /// </summary>
        public string Street { get; set; } = "";

        /// <summary>
        /// The postal code of the customer's address.
        /// </summary>
        public string PostalCode { get; set; } = "";
    }
}
