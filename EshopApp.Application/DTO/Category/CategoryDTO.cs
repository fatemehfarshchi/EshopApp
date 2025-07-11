namespace EshopApp.Application.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) representing a product category, including hierarchical relationships.
    /// </summary>
    public class CategoryDTO
    {
        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// The unique identifier for the category.
        /// </summary>
        public Guid Id { get; set; }

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

        /// <summary>
        /// The collection of child categories (subcategories).
        /// </summary>
        public ICollection<CategoryDTO> Children { get; set; } = new List<CategoryDTO>();
    }
}
