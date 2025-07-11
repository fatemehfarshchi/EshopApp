namespace EshopApp.Application.DTO;

/// <summary>
/// Data Transfer Object (DTO) for filtering invoices by customer and date range.
/// </summary>
public class InvoiceFilterDTO
{
    /// <summary>
    /// The unique identifier of the customer to filter invoices by (optional).
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// The start date for filtering invoices (optional).
    /// </summary>
    public DateTime? FromDate { get; set; }

    /// <summary>
    /// The end date for filtering invoices (optional).
    /// </summary>
    public DateTime? ToDate { get; set; }
}
