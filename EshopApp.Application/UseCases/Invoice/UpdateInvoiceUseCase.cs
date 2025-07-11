using EshopApp.Application.DTO;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.UseCases;

/// <summary>
/// Use case for updating an existing invoice and its items in the system.
/// </summary>
public class UpdateInvoiceUseCase
{
    /// <summary>
    /// The repository for accessing and updating invoice data.
    /// </summary>
    private readonly IInvoiceRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateInvoiceUseCase"/> class.
    /// </summary>
    /// <param name="repository">The invoice repository dependency.</param>
    public UpdateInvoiceUseCase(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Updates the specified invoice and its items with new values from the DTO.
    /// </summary>
    /// <param name="dto">The DTO containing updated invoice information.</param>
    /// <exception cref="Exception">Thrown if the invoice is not found.</exception>
    public async Task ExecuteAsync(UpdateInvoiceDto dto)
    {
        // Retrieve the invoice by ID
        var invoice = await _repository.GetByIdAsync(dto.Id);
        if (invoice == null)
            throw new Exception("Invoice not found");

        // Update invoice properties
        invoice.Date = dto.Date;
        invoice.CustomerId = dto.CustomerId;
        invoice.Status = dto.Status;
        invoice.PaymentMethod = dto.PaymentMethod;

        // Clear and update invoice items
        invoice.Items.Clear();
        foreach (var itemDto in dto.Items)
        {
            invoice.Items.Add(new InvoiceItem
            {
                ProductId = itemDto.ProductId,
                Quantity = itemDto.Quantity,
                UnitPrice = itemDto.UnitPrice
            });
        }

        // Persist the changes
        await _repository.UpdateAsync(invoice);
    }
}
