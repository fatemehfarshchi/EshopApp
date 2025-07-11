namespace EshopApp.Application.DTO;

/// <summary>
/// Data Transfer Object (DTO) for updating an existing invoice item.
/// </summary>
public class UpdateInvoiceItemDto
{
    /// <summary>
    /// The unique identifier of the invoice item to update.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The unique identifier of the product for the invoice item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The updated quantity of the product in the invoice item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The updated unit price of the product in the invoice item.
    /// </summary>
    public decimal UnitPrice { get; set; }
}
