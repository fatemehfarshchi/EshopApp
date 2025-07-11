
using EshopApp.Application.UseCase;
using EshopApp.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Application.DTOs;
using EshopApp.Application.UseCases;

namespace EshopApp.API.Controllers
{

    /// <summary>
    /// API controller for managing product operations such as create, retrieve, update, delete, get by ID, and assign to category.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductUseCase _createProductUseCase;
        private readonly GetProductsUseCase _getProductsUseCase;
        private readonly DeleteProductUseCase _deleteProductUseCase;
        private readonly UpdateProductUseCase _updateProductUseCase;
        private readonly GetProductByIdUseCase _getProductByIdUseCase;
        private readonly AssignProductToCategoryUseCase _assignProductToCategoryUseCase;

        /// <summary>
        /// Constructor that injects product use case dependencies.
        /// </summary>
        public ProductController(CreateProductUseCase createProductUseCase, GetProductsUseCase getProductsUseCase, DeleteProductUseCase deleteProductUseCase, UpdateProductUseCase updateProductUseCase, GetProductByIdUseCase getProductByIdUseCase, AssignProductToCategoryUseCase assignProductToCategoryUseCase)
        {
            _createProductUseCase = createProductUseCase;
            _getProductsUseCase = getProductsUseCase;
            _deleteProductUseCase = deleteProductUseCase;
            _updateProductUseCase = updateProductUseCase;
            _getProductByIdUseCase = getProductByIdUseCase;
            _assignProductToCategoryUseCase = assignProductToCategoryUseCase;
        }

        
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="dto">The DTO containing product data.</param>
        /// <returns>Action result with the created product ID and message.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDTO dto)
        {
            var id = await _createProductUseCase.ExecuteAsync(dto);
            return Ok(OperationResult<Guid>.Ok(id, "Product created successfully"));
        }

    
   
        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>List of product DTOs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsAsync()
        {
            var result = await _getProductsUseCase.ExecuteAsync();
            return Ok(result);
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>Action result indicating success or failure.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            try
            {
                await _deleteProductUseCase.ExecuteAsync(id);
                return Ok(new { message = "Product deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

       
        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="dto">The DTO containing updated product data.</param>
        /// <returns>No content if update is successful; otherwise, bad request.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Mismatched product ID.");

            await _updateProductUseCase.ExecuteAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product DTO if found; otherwise, not found.</returns>
        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _getProductByIdUseCase.ExecuteAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        /// <summary>
        /// Assigns a product to a category.
        /// </summary>
        /// <param name="productId">The ID of the product to assign.</param>
        /// <param name="categoryId">The ID of the category to assign the product to.</param>
        /// <returns>Action result indicating success or failure.</returns>
        [HttpPost("product/{productId}/assign-category/{categoryId}")]
        public async Task<IActionResult> AssignCategory(Guid productId, Guid categoryId)
        {
            var result = await _assignProductToCategoryUseCase.ExecuteAsync(productId, categoryId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }


    }
}