using EshopApp.Shared;

namespace EshopApp.Domain.Entities
{

    /// <summary>
    /// Represents a product category, which can have a parent and child categories (for hierarchical organization).
    /// </summary>
    public class Category
    {
        /// <summary>
        /// The unique identifier for the category.
        /// </summary>
        public Guid? CategoryId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// The unique identifier of the parent category, if any.
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// The parent category entity, if any.
        /// </summary>
        public Category? Parent { get; set; }

        /// <summary>
        /// The collection of child categories.
        /// </summary>
        public ICollection<Category> Children { get; set; } = new List<Category>();

        /// <summary>
        /// The image URL associated with the category.
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// The display order for sorting categories.
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Private constructor for EF Core and serialization.
        /// </summary>
        private Category() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <param name="parentId">The parent category's unique identifier, if any.</param>
        /// <param name="imageUrl">The image URL for the category.</param>
        /// <param name="displayOrder">The display order for the category.</param>
        public Category(string name, Guid? parentId = null, string? imageUrl = null, int displayOrder = 0)
        {
            Name = name;
            ParentId = parentId;
            ImageUrl = imageUrl;
            DisplayOrder = displayOrder;
        }
    }

}