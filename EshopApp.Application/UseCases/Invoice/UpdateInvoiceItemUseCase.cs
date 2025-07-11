using EshopApp.Application.DTO;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.UseCases;

/// <summary>
/// Use case for updating an existing invoice item's details in the system.
/// </summary>
public class UpdateInvoiceItemUseCase
{
    /// <summary>
    /// The repository for accessing and updating invoice item data.
    /// </summary>
    private readonly IInvoiceItemRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateInvoiceItemUseCase"/> class.
    /// </summary>
    /// <param name="repository">The invoice item repository dependency.</param>
    public UpdateInvoiceItemUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Updates the specified invoice item with new values from the DTO.
    /// </summary>
    /// <param name="dto">The DTO containing updated invoice item information.</param>
    /// <exception cref="Exception">Thrown if the invoice item is not found.</exception>
    public async Task ExecuteAsync(UpdateInvoiceItemDto dto)
    {
        // Retrieve the invoice item by ID
        var invoiceitem = await _repository.GetByIdAsync(dto.Id);
        if (invoiceitem == null)
            throw new Exception("InvoiceItem not found");

        // Update invoice item properties
        invoiceitem.ProductId = dto.ProductId;
        invoiceitem.Quantity = dto.Quantity;
        invoiceitem.UnitPrice = dto.UnitPrice;

        // Persist the changes
        await _repository.UpdateAsync(invoiceitem);
    }
}
