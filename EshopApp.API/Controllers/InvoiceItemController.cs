using EshopApp.Application.UseCase;
using EshopApp.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Application.UseCases;
using MediatR;
using EshopApp.Application.UseCase.Invoice;

namespace EshopApp.API.Controllers
{
    /// <summary>
    /// API controller for managing invoice item operations such as delete and update.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceItemController : ControllerBase
    {
        private readonly DeleteInvoiceItemUseCase _deleteInvoiceItemUseCase;
        private readonly UpdateInvoiceItemUseCase _updateInvoiceItemUseCase;
        private readonly GetInvoiceItemsByInvoiceIdUseCase _getInvoiceItemsByInvoiceIdUseCase;

        /// <summary>
        /// Constructor that injects invoice item use case dependencies.
        /// </summary>
        public InvoiceItemController(DeleteInvoiceItemUseCase deleteInvoiceItemUseCase, UpdateInvoiceItemUseCase updateInvoiceItemUseCase, GetInvoiceItemsByInvoiceIdUseCase getInvoiceItemsByInvoiceIdUseCase)
        {
            _deleteInvoiceItemUseCase = deleteInvoiceItemUseCase;
            _updateInvoiceItemUseCase = updateInvoiceItemUseCase;
            _getInvoiceItemsByInvoiceIdUseCase = getInvoiceItemsByInvoiceIdUseCase;
        }

        /// <summary>
        /// Deletes an invoice item by its ID.
        /// </summary>
        /// <param name="id">The ID of the invoice item to delete.</param>
        /// <returns>Action result indicating success or failure.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceItemAsync(Guid id)
        {
            try
            {
                await _deleteInvoiceItemUseCase.ExecuteAsync(id);
                return Ok(new { message = "InvoiceItem deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing invoice item.
        /// </summary>
        /// <param name="id">The ID of the invoice item to update.</param>
        /// <param name="dto">The DTO containing updated invoice item data.</param>
        /// <returns>No content if update is successful; otherwise, bad request.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInvoiceItemDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Mismatched invoiceitem ID.");

            await _updateInvoiceItemUseCase.ExecuteAsync(dto);
            return NoContent();
        }
        
        /// <summary>
        /// Retrieves all invoice items for a specific invoice by its ID.
        /// </summary>
        /// <param name="invoiceId">The ID of the invoice to retrieve items for.</param>
        /// <returns>List of invoice item DTOs for the specified invoice.</returns>
        [HttpGet("by-invoice/{invoiceId}")]
        public async Task<IActionResult> GetItemsByInvoiceId(Guid invoiceId)
        {
            var items = await _getInvoiceItemsByInvoiceIdUseCase.ExecuteAsync(invoiceId);
            return Ok(items);
        }

    

    }
}