using EshopApp.Domain.ValueObjects;
using EshopApp.Shared;

namespace EshopApp.Domain.Entities
{
    /// <summary>
    /// Represents a customer entity, including their products and address.
    /// </summary>
    public class Customer 
    {
        /// <summary>
        /// The unique identifier for the customer.
        /// </summary>
        public Guid Id { get; set; } 

        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The collection of products associated with the customer.
        /// </summary>
        public ICollection<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// The address of the customer.
        /// </summary>
        public Address? Address { get; private set; }

        /// <summary>
        /// Private constructor for EF Core and serialization.
        /// </summary>
        private Customer() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="name">The name of the customer.</param>
        /// <param name="address">The address of the customer.</param>
        public Customer(string name, Address address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
        }

        /// <summary>
        /// Adds a product to the customer's product collection.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        /// <summary>
        /// Adds multiple products to the customer's product collection.
        /// </summary>
        /// <param name="products">The collection of products to add.</param>
        public void AddProducts(ICollection<Product> products)
        {
            foreach (var product in products)
            {
                products.Add(product); // Note: This line may cause an infinite loop or exception. Consider revising.
            }
        }
    }
}