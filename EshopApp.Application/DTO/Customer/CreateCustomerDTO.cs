namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a new customer.
    /// </summary>
    public class CreateCustomerDTO
    {
        /// <summary>
        /// The name of the customer to create.
        /// </summary>
        public string Name { get; set; } = string.Empty;

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

