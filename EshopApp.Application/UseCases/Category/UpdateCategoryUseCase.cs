using EshopApp.Application.DTO;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.UseCases;

/// <summary>
/// Use case for updating an existing category's details in the system.
/// </summary>
public class UpdateCategoryUseCase
{
    /// <summary>
    /// The repository for accessing and updating category data.
    /// </summary>
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCategoryUseCase"/> class.
    /// </summary>
    /// <param name="repository">The category repository dependency.</param>
    public UpdateCategoryUseCase(ICategoryRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Updates the specified category with new values from the DTO.
    /// </summary>
    /// <param name="dto">The DTO containing updated category information.</param>
    /// <exception cref="Exception">Thrown if the category is not found or if a category is set as its own parent.</exception>
    public async Task ExecuteAsync(UpdateCategoryDto dto)
    {
        // Retrieve the category by ID
        var category = await _repository.GetByIdAsync(dto.Id);
        if (category == null)
            throw new Exception("Category not found");

        // Prevent a category from being its own parent
        if (dto.ParentId == dto.Id)
            throw new Exception("A category cannot be its own parent.");

        // Update category properties
        category.Name = dto.Name;
        category.ParentId = dto.ParentId;
        category.ImageUrl = dto.ImageUrl;
        category.DisplayOrder = dto.DisplayOrder;

        // Persist the changes
        await _repository.UpdateAsync(category);
    }
}
