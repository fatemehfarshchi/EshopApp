using EshopApp.Application.DTO;
using EshopApp.Application.Interfaces;
using Microsoft.VisualBasic;

namespace EshopApp.Application.UseCases;

/// <summary>
/// Use case for updating an existing customer's details in the system.
/// </summary>
public class UpdateCustomerUseCase
{
    /// <summary>
    /// The repository for accessing and updating customer data.
    /// </summary>
    private readonly ICustomerRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCustomerUseCase"/> class.
    /// </summary>
    /// <param name="repository">The customer repository dependency.</param>
    public UpdateCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Updates the specified customer with new values from the DTO.
    /// </summary>
    /// <param name="dto">The DTO containing updated customer information.</param>
    /// <exception cref="Exception">Thrown if the customer is not found.</exception>
    public async Task ExecuteAsync(UpdateCustomerDto dto)
    {
        // Retrieve the customer by ID
        var customer = await _repository.GetByIdAsync(dto.Id);
        if (customer == null)
            throw new Exception("Customer not found.");

        // Update customer properties
        customer.Name = dto.Name;

        // Persist the changes
        await _repository.UpdateAsync(customer);
    }
}
