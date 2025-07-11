using EshopApp.Domain.Enums;
using EshopApp.Shared;


namespace EshopApp.Domain.Entities
{
    /// <summary>
    /// Represents an invoice entity, including its items, customer, date, payment method, and status.
    /// </summary>
    public class Invoice 
    {
        /// <summary>
        /// The unique identifier for the invoice.
        /// </summary>
        public Guid Id { get; set; } 

        /// <summary>
        /// The unique identifier of the customer associated with the invoice.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The date the invoice was issued.
        /// </summary>
        public DateTime Date { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// The backing field for the list of invoice items.
        /// </summary>
        private readonly List<InvoiceItem> _Items = new();

        /// <summary>
        /// The list of items included in the invoice.
        /// </summary>
        public List<InvoiceItem> Items => _Items;

        /// <summary>
        /// The payment method used for the invoice.
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// The status of the invoice.
        /// </summary>
        public InvoiceStatus Status { get; set; }

        /// <summary>
        /// Parameterless constructor for EF Core and serialization.
        /// </summary>
        public Invoice() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class with the specified customer, date, and items.
        /// </summary>
        /// <param name="customer">The customer associated with the invoice.</param>
        /// <param name="date">The date the invoice was issued.</param>
        /// <param name="items">The list of invoice items.</param>
        public Invoice(Customer customer, DateTime date, List<InvoiceItem> items)
        {
            Id = Guid.NewGuid();
            CustomerId = customer.Id;
            Date = date;

            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        /// <summary>
        /// Adds an item to the invoice.
        /// </summary>
        /// <param name="item">The invoice item to add.</param>
        public void AddItem(InvoiceItem item)
        {
            _Items.Add(item);
        }

        /// <summary>
        /// Calculates the total price of the invoice by summing the price of all items.
        /// </summary>
        /// <returns>The total price of the invoice.</returns>
        public decimal TotalPrice()
        {
            return _Items.Sum(item => item.UnitPrice * item.Quantity);
        }
    }
}
