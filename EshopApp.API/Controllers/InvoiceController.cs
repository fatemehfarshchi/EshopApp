using EshopApp.Application.UseCase;
using EshopApp.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Application.UseCases;
using EshopApp.Application;
using EshopApp.Application.DTOs;

namespace EshopApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class InvoiceController : ControllerBase
    {
        private readonly GetInvoicesUseCase _getInvoicesUseCase;
        private readonly CreateInvoiceUseCase _createInvoiceUseCase;
        private readonly DeleteInvoiceUseCase _deleteInvoiceUseCase;
        private readonly UpdateInvoiceUseCase _updateInvoiceUseCase;
        private readonly GetFilteredInvoicesUseCase _getFilteredInvoicesUseCase;
        private readonly GetCustomerTotalInvoiceUseCase _getCustomerTotalInvoiceUseCase;

        public InvoiceController(GetInvoicesUseCase getInvoicesUseCase, CreateInvoiceUseCase createInvoiceUseCase, DeleteInvoiceUseCase deleteInvoiceUseCase, UpdateInvoiceUseCase updateInvoiceUseCase, GetFilteredInvoicesUseCase getFilteredInvoicesUseCase, GetCustomerTotalInvoiceUseCase getCustomerTotalInvoiceUseCase)
        {
            _getInvoicesUseCase = getInvoicesUseCase;
            _createInvoiceUseCase = createInvoiceUseCase;
            _deleteInvoiceUseCase = deleteInvoiceUseCase;
            _updateInvoiceUseCase = updateInvoiceUseCase;
            _getFilteredInvoicesUseCase = getFilteredInvoicesUseCase;
            _getCustomerTotalInvoiceUseCase = getCustomerTotalInvoiceUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAllInvoicesAsync()
        {
            var result = await _getInvoicesUseCase.ExecuteAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoiceAsync([FromBody] CreateInvoiceDTO dto)
        {
            try
            {
                await _createInvoiceUseCase.ExecuteAsync(dto);
                return Ok(new { message = "invoice created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceAsync(Guid id)
        {
            try
            {
                await _deleteInvoiceUseCase.ExecuteAsync(id);
                return Ok(new { message = "Invoice deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing invoice.
        /// </summary>
        /// <param name="id">The ID of the invoice to update.</param>
        /// <param name="dto">The DTO containing updated invoice data.</param>
        /// <returns>No content if update is successful; otherwise, bad request.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInvoiceDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Mismatched invoice ID.");

            await _updateInvoiceUseCase.ExecuteAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// Searches for invoices based on filter criteria.
        /// </summary>
        /// <param name="filter">The filter DTO for searching invoices.</param>
        /// <returns>List of filtered invoice DTOs.</returns>
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] InvoiceFilterDTO filter)
        {
            var result = await _getFilteredInvoicesUseCase.ExecuteAsync(filter);
            return Ok(result);
        }

        /// <summary>
        /// Gets the total invoice amount for a customer.
        /// </summary>
        /// <param name="dto">The DTO containing customer information.</param>
        /// <returns>Total invoice amount or not found if customer/invoices do not exist.</returns>
        [HttpPost("customer-total")]
        public async Task<IActionResult> GetCustomerTotal([FromBody] CustomerTotalInvoiceInputDto dto)
        {
            var result = await _getCustomerTotalInvoiceUseCase.ExecuteAsync(dto);
            if (result == null) return NotFound("Customer not found or no invoices.");

            return Ok(result);
        }
    }
}