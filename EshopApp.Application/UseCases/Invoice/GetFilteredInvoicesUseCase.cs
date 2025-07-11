using EshopApp.Application.DTO;
using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCases;

/// <summary>
/// Use case for retrieving filtered invoices based on customer and date range.
/// </summary>
public class GetFilteredInvoicesUseCase
{
    private readonly IInvoiceRepository _repository;

    /// <summary>
    /// Constructor that injects the invoice repository dependency.
    /// </summary>
    /// <param name="repository">The repository for invoice data.</param>
    public GetFilteredInvoicesUseCase(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the retrieval of filtered invoices.
    /// </summary>
    /// <param name="filter">The filter criteria for invoices.</param>
    /// <returns>List of filtered invoice DTOs.</returns>
    public async Task<List<GetInvoiceDTO>> ExecuteAsync(InvoiceFilterDTO filter)
    {
        // Retrieve filtered invoices from the repository
        var invoices = await _repository.GetFilteredAsync(filter.CustomerId, filter.FromDate, filter.ToDate);

        // Map the invoice entities to DTOs
        return invoices.Select(invoice => new GetInvoiceDTO
        {
            Id = invoice.Id,
            IssuedDate = invoice.Date,
            TotalAmount = invoice.Items.Sum(i => i.UnitPrice * i.Quantity),
            PaymentMethod = invoice.PaymentMethod,
            Status = invoice.Status,
            Items = invoice.Items.Select(item => new GetInvoiceItemDTO
            {
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            }).ToList()
        }).ToList();
    }
}
