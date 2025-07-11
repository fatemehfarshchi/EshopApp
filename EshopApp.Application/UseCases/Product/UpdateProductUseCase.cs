using EshopApp.Application.DTOs;
using EshopApp.Application.Interfaces;
namespace EshopApp.Application.UseCases;

/// <summary>
/// Use case for updating an existing product's details in the system.
/// </summary>
public class UpdateProductUseCase
{
    /// <summary>
    /// The repository for accessing and updating product data.
    /// </summary>
    private readonly IProductRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateProductUseCase"/> class.
    /// </summary>
    /// <param name="repository">The product repository dependency.</param>
    public UpdateProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Updates the specified product with new values from the DTO.
    /// </summary>
    /// <param name="dto">The DTO containing updated product information.</param>
    /// <returns>True if the product was found and updated; otherwise, false.</returns>
    public async Task<bool> ExecuteAsync(UpdateProductDto dto)
    {
        // Retrieve the product by ID
        var product = await _repository.GetByIdAsync(dto.Id);
        if (product == null)
            return false;

        // Update product properties
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.CategoryID = dto.CategoryId;
        product.Description = dto.Description;

        // Persist the changes
        await _repository.UpdateAsync(product);
        return true;
    }
}
