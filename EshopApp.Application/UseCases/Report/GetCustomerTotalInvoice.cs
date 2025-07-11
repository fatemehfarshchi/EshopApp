using EshopApp.Application.DTOs;
using EshopApp.Application.Interfaces;

/// <summary>
/// Use case for retrieving the total invoice information for a specific customer.
/// </summary>
public class GetCustomerTotalInvoiceUseCase
{
    /// <summary>
    /// The repository for accessing invoice data.
    /// </summary>
    private readonly IInvoiceRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCustomerTotalInvoiceUseCase"/> class.
    /// </summary>
    /// <param name="repository">The invoice repository dependency.</param>
    public GetCustomerTotalInvoiceUseCase(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Retrieves the total invoice information for the specified customer.
    /// </summary>
    /// <param name="input">The input DTO containing the customer ID.</param>
    /// <returns>The <see cref="CustomerTotalInvoiceDto"/> for the customer, or null if not found.</returns>
    public async Task<CustomerTotalInvoiceDto?> ExecuteAsync(CustomerTotalInvoiceInputDto input)
    {
        // Retrieve the total invoice information for the customer
        return await _repository.GetCustomerTotalInvoiceAsync(input.CustomerId);
    }
}
