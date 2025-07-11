namespace EshopApp.Application.DTO;

/// <summary>
/// Data Transfer Object (DTO) for retrieving invoice item details.
/// </summary>
public class GetInvoiceItemDTO
{
    /// <summary>
    /// The name of the product in the invoice item.
    /// </summary>
    public string ProductName { get; set; } = "";

    /// <summary>
    /// The unique identifier of the product in the invoice item.
    /// </summary>
    public Guid ProductId{ get; set; }

    /// <summary>
    /// The unique identifier of the invoice item.
    /// </summary>
    public Guid Id{ get; set; }

    /// <summary>
    /// The quantity of the product in the invoice item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the product in the invoice item.
    /// </summary>
    public decimal UnitPrice { get; set; }
}
