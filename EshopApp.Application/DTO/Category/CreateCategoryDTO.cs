namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a new product category.
    /// </summary>
    public class CreateCategoryDTO
    {
        /// <summary>
        /// The name of the category to create.
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// The URL of the category image (optional).
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// The display order of the category.
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// The unique identifier of the parent category (optional).
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}
