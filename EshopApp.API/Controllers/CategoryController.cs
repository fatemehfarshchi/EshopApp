
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
    /// API controller for managing category operations such as create, retrieve, update, and delete.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CreateCategoryUseCase _createCategoryUseCase;
        private readonly GetCategoriesUseCase _getCategoriesUseCase;
        private readonly DeleteCategoryUseCase _deleteCategoryUseCase;
        private readonly UpdateCategoryUseCase _updateCategoryUseCase;

        /// <summary>
        /// Constructor that injects category use case dependencies.
        /// </summary>
        public CategoryController(CreateCategoryUseCase createCategoryUseCase, GetCategoriesUseCase getCategoriesUseCase, DeleteCategoryUseCase deleteCategoryUseCase, UpdateCategoryUseCase updateCategoryUseCase)
        {
            _createCategoryUseCase = createCategoryUseCase;
            _getCategoriesUseCase = getCategoriesUseCase;
            _deleteCategoryUseCase = deleteCategoryUseCase;
            _updateCategoryUseCase = updateCategoryUseCase;
        }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="dto">The DTO containing category data.</param>
        /// <returns>Action result indicating success or failure.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryDTO dto)
        {
            try
            {
                await _createCategoryUseCase.ExecuteAsync(dto);
                return Ok(new { message = "Category created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>List of category DTOs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategoriesAsync()
        {
            var result = await _getCategoriesUseCase.ExecuteAsync();
            return Ok(result);
        }

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category to delete.</param>
        /// <returns>Action result indicating success or failure.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(Guid id)
        {
            try
            {
                await _deleteCategoryUseCase.ExecuteAsync(id);
                return Ok(new { message = "Category deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="id">The ID of the category to update.</param>
        /// <param name="dto">The DTO containing updated category data.</param>
        /// <returns>No content if update is successful; otherwise, bad request.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Mismatched category ID.");

            await _updateCategoryUseCase.ExecuteAsync(dto);
            return NoContent();
        }
    }
}