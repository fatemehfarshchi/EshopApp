using EshopApp.Application.UseCase;
using EshopApp.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Application.DTOs;
using EshopApp.Application.UseCases;


/// <summary>
/// API controller for managing store information operations such as create, retrieve, and update.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class StoreInfoController : ControllerBase
{
    private readonly GetStoreInfoUseCase _getUseCase;
    private readonly UpdateStoreInfoUseCase _updateUseCase;
    private readonly CreateStoreInfoUseCase _createStoreInfoUseCase;

    /// <summary>
    /// Constructor that injects store info use case dependencies.
    /// </summary>
    public StoreInfoController(GetStoreInfoUseCase getUseCase, UpdateStoreInfoUseCase updateUseCase, CreateStoreInfoUseCase createStoreInfoUseCase)
    {
        _getUseCase = getUseCase;
        _updateUseCase = updateUseCase;
        _createStoreInfoUseCase = createStoreInfoUseCase;
    }


    /// <summary>
    /// Retrieves the store information.
    /// </summary>
    /// <returns>The store info DTO if found; otherwise, not found.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var info = await _getUseCase.ExecuteAsync();
        if (info == null) return NotFound();
        return Ok(info);
    }

    /// <summary>
    /// Updates the store information.
    /// </summary>
    /// <param name="dto">The DTO containing updated store info.</param>
    /// <returns>No content if update is successful; otherwise, not found.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] StoreInfoDto dto)
    {
        var result = await _updateUseCase.ExecuteAsync(dto);
        if (!result) return NotFound();
        return NoContent();
    }

    /// <summary>
    /// Creates new store information.
    /// </summary>
    /// <param name="dto">The DTO containing store info to create.</param>
    /// <returns>Created result with the new store info.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StoreInfoDto dto)
    {
        var id = await _createStoreInfoUseCase.ExecuteAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = id }, dto);
    }

}
