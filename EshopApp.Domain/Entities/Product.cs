using EshopApp.Shared;

namespace EshopApp.Domain.Entities
{
    /// <summary>
    /// Represents a product entity, including its category, price, stock, and description.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The unique identifier for the product.
        /// </summary>
        public Guid Id { get; set; } 

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// The price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The available stock quantity for the product.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// The unique identifier of the category this product belongs to.
        /// </summary>
        public Guid? CategoryID { get; set; }

        /// <summary>
        /// The category entity this product belongs to.
        /// </summary>
        public Category? Category { get; set; } = null!;

        /// <summary>
        /// The description of the product.
        /// </summary>
        public string? Description { get; set; } 

        /// <summary>
        /// Parameterless constructor for EF Core and serialization.
        /// </summary>
        public Product() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified details.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="stock">The available stock quantity.</param>
        /// <param name="categoryid">The unique identifier of the category.</param>
        /// <param name="discription">The description of the product.</param>
        public Product(string name, decimal price, int stock, Guid categoryid, string discription)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Stock = stock;
            CategoryID = categoryid;
            Description = discription;
        }

        /// <summary>
        /// Increases the stock quantity by the specified amount.
        /// </summary>
        /// <param name="amount">The amount to add to the stock.</param>
        public void UpdateStock(int amount) {
            Stock += amount;
        }

        /// <summary>
        /// Decreases the stock quantity by the specified amount.
        /// Throws an exception if there is not enough stock.
        /// </summary>
        /// <param name="quantity">The amount to subtract from the stock.</param>
        public void DecreaseStock(int quantity)
        {
            if (quantity > Stock)
                throw new InvalidOperationException("Not enough stock available");

            Stock -= quantity;
        }   
    }
}