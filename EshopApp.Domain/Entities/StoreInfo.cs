using EshopApp.Shared;

namespace EshopApp.Domain.Entities;

/// <summary>
/// Represents store information, including name, address, phone, and website.
/// </summary>
public class StoreInfo 
{
    /// <summary>
    /// The unique identifier for the store information.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The name of the store.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The address of the store.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// The phone number of the store.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// The website URL of the store.
    /// </summary>
    public string Website { get; set; } = string.Empty;
}
