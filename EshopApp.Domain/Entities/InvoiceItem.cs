using EshopApp.Shared;

namespace EshopApp.Domain.Entities
{
    /// <summary>
    /// Represents an item within an invoice, including product, quantity, and price details.
    /// </summary>
    public class InvoiceItem
    {
        /// <summary>
        /// The unique identifier for the invoice item.
        /// </summary>
        public Guid Id { get; set; } 

        /// <summary>
        /// The unique identifier of the invoice this item belongs to.
        /// </summary>
        public Guid? InvoiceId { private set; get; }

        /// <summary>
        /// The invoice entity this item belongs to.
        /// </summary>
        public Invoice? Invoice { get; set; } = null!;

        /// <summary>
        /// The unique identifier of the product for this invoice item.
        /// </summary>
        public Guid? ProductId { set; get; }

        /// <summary>
        /// The quantity of the product in this invoice item.
        /// </summary>
        public int Quantity { set; get; }

        /// <summary>
        /// The unit price of the product in this invoice item.
        /// </summary>
        public decimal UnitPrice { set; get; }

        /// <summary>
        /// The name of the product in this invoice item.
        /// </summary>
        public string ProductName { set; get; } = string.Empty;

        /// <summary>
        /// Parameterless constructor for EF Core and serialization.
        /// </summary>
        public InvoiceItem(){}

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceItem"/> class with the specified product, quantity, and unit price.
        /// </summary>
        /// <param name="product">The product associated with this invoice item.</param>
        /// <param name="quantity">The quantity of the product.</param>
        /// <param name="unitprice">The unit price of the product.</param>
        public InvoiceItem(Product product, int quantity, decimal unitprice)
        {
            Id = Guid.NewGuid();
            ProductId = product.Id;
            Quantity = quantity;
            UnitPrice = unitprice;
            ProductName = product.Name;
        }
    }
}