using EshopApp.Application.UseCase;
using EshopApp.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Application.DTOs;
using EshopApp.Application.UseCases;

/// <summary>
/// API controller for managing user operations such as registration, login, and retrieval.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly RegisterUserUseCase _registerUserUseCase;
    private readonly RegisterUserByAdminUseCase _registerUserByAdminUseCase;
    private readonly LoginUserUseCase _loginUserUseCase;
    private readonly GetUserUseCase _getUserUseCase;

    /// <summary>
    /// Constructor that injects user use case dependencies.
    /// </summary>
    public UserController(RegisterUserUseCase registerUserUseCase, RegisterUserByAdminUseCase registerUserByAdminUseCase, LoginUserUseCase loginUserUseCase, GetUserUseCase getUserUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
        _registerUserByAdminUseCase = registerUserByAdminUseCase;
        _loginUserUseCase = loginUserUseCase;
        _getUserUseCase = getUserUseCase;
    }


    /// <summary>
    /// Retrieves all users.
    /// </summary>
    /// <returns>List of user DTOs.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _getUserUseCase.ExecuteAsync();
        return Ok(users);
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="dto">The DTO containing user registration data.</param>
    /// <returns>Status code 201 if successful; otherwise, bad request.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
    {
        try
        {
            await _registerUserUseCase.ExecuteAsync(dto);
            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Registers a new user by an admin.
    /// </summary>
    /// <param name="dto">The DTO containing user registration data for admin.</param>
    /// <returns>Status code 201 if successful; otherwise, bad request.</returns>
    [HttpPost("admin/register")]
    public async Task<IActionResult> RegisterByAdmin([FromBody] RegisterUserByAdminDto dto)
    {
        try
        {
            await _registerUserByAdminUseCase.ExecuteAsync(dto);
            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Authenticates a user and returns a result if successful.
    /// </summary>
    /// <param name="dto">The DTO containing login credentials.</param>
    /// <returns>Ok with result if successful; otherwise, unauthorized.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
        var result = await _loginUserUseCase.ExecuteAsync(dto);
        if (result == null)
            return Unauthorized(new { message = "Invalid credentials" });

        return Ok(result);
    }
}
