namespace EshopApp.Application.DTOs;

/// <summary>
/// Data Transfer Object (DTO) for updating an existing product.
/// </summary>
public class UpdateProductDto
{
    /// <summary>
    /// The unique identifier of the product to update.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The updated name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The updated price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The unique identifier of the category the product belongs to.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// The updated description of the product (optional).
    /// </summary>
    public string? Description { get; set; }
}
