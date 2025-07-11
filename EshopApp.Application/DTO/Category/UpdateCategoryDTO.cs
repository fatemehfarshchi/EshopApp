namespace EshopApp.Application;

/// <summary>
/// Data Transfer Object (DTO) for updating an existing product category.
/// </summary>
public class UpdateCategoryDto
{
    /// <summary>
    /// The unique identifier of the category to update.
    /// </summary>
    public Guid Id { get; set; } 

    /// <summary>
    /// The updated name of the category.
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// The updated URL of the category image (optional).
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// The updated display order of the category.
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// The updated unique identifier of the parent category (optional).
    /// </summary>
    public Guid? ParentId { get; set; }
}