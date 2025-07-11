
using EshopApp.Application.UseCase;
using EshopApp.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Application;
using EshopApp.Application.UseCases;

namespace EshopApp.API.Controllers
{
    /// <summary>
    /// API controller for managing customer operations such as create, retrieve, update, and delete.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CreateCustomerUseCase _createCustomerUseCase;
        private readonly GetCustomersUseCase _getCustomersUseCase;
        private readonly DeleteCustomerUseCase _deleteCustomerUseCase;
        private readonly UpdateCustomerUseCase _updateCustomerUseCase;
        private readonly GetCustomerByIdUseCase _getCustomerByIdUseCase;

        /// <summary>
        /// Constructor that injects customer use case dependencies.
        /// </summary>
        public CustomerController(CreateCustomerUseCase createCustomerUseCase, GetCustomersUseCase getCustomersUseCase, DeleteCustomerUseCase deleteCustomerUseCase, UpdateCustomerUseCase updateCustomerUseCase, GetCustomerByIdUseCase getCustomerByIdUseCase)
        {
            _createCustomerUseCase = createCustomerUseCase;
            _getCustomersUseCase = getCustomersUseCase;
            _deleteCustomerUseCase = deleteCustomerUseCase;
            _updateCustomerUseCase = updateCustomerUseCase;
            _getCustomerByIdUseCase = getCustomerByIdUseCase;
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="dto">The DTO containing customer data.</param>
        /// <returns>Action result indicating success or failure.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerDTO dto)
        {
            try
            {
                await _createCustomerUseCase.ExecuteAsync(dto);
                return Ok(new { message = "Customer created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        /// <returns>List of customer DTOs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomersAsync()
        {
            var result = await _getCustomersUseCase.ExecuteAsync();
            return Ok(result);
        }

        /// <summary>
        /// Deletes a customer by its ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>Action result indicating success or failure.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(Guid id)
        {
            try
            {
                await _deleteCustomerUseCase.ExecuteAsync(id);
                return Ok(new { message = "Customer deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="id">The ID of the customer to update.</param>
        /// <param name="dto">The DTO containing updated customer data.</param>
        /// <returns>No content if update is successful; otherwise, bad request.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Mismatched customer ID.");

            await _updateCustomerUseCase.ExecuteAsync(dto);
            return NoContent();
        }
        /// <summary>
        /// Retrieves a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to retrieve.</param>
        /// <returns>The customer DTO if found; otherwise, not found.</returns>

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _getCustomerByIdUseCase.ExecuteAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

    }
}