using EshopApp.Application.DTO;

namespace EshopApp.Application;

/// <summary>
/// Data Transfer Object (DTO) for updating an existing customer.
/// </summary>
public class UpdateCustomerDto
{
    /// <summary>
    /// The unique identifier of the customer to update.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The updated name of the customer.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The updated city where the customer resides.
    /// </summary>
    public string City { get; set; } = "";

    /// <summary>
    /// The updated street address of the customer.
    /// </summary>
    public string Street { get; set; } = "";

    /// <summary>
    /// The updated postal code of the customer's address.
    /// </summary>
    public string PostalCode { get; set; } = "";
}
