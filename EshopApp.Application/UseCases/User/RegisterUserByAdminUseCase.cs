using EshopApp.Application.DTO;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using System.Security.Cryptography;


namespace EshopApp.Application.UseCases;

/// <summary>
/// Use case for registering a new user by an admin in the system.
/// </summary>
public class RegisterUserByAdminUseCase
{
    /// <summary>
    /// The repository for accessing and adding user data.
    /// </summary>
    private readonly IUserRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUserByAdminUseCase"/> class.
    /// </summary>
    /// <param name="repository">The user repository dependency.</param>
    public RegisterUserByAdminUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Registers a new user using the provided DTO, only if the requester is an admin.
    /// </summary>
    /// <param name="dto">The DTO containing new user information and admin credentials.</param>
    /// <exception cref="Exception">Thrown if the requester is not an admin or if the user already exists.</exception>
    public async Task ExecuteAsync(RegisterUserByAdminDto dto)
    {
        // Check if the admin user exists and has the Admin role
        var adminUser = await _repository.ExistsByUserNameAsync(dto.AdminUserName);
        if (adminUser == null || adminUser.Role != "Admin")
            throw new Exception("Only admins can create new users");

        // Check if the new user already exists
        var existingUser = await _repository.ExistsByUserNameAsync(dto.NewUserName);
        if (existingUser != null)
            throw new Exception("User already exists");

        // Hash the new user's password
        var passwordHash = Hash(dto.Password);

        // Create the new user entity
        var user = new User
        {
            UserName = dto.NewUserName,
            PasswordHash = passwordHash,
            Role = dto.Role,
        };

        // Add the new user to the repository
        await _repository.AddAsync(user);
    }

    /// <summary>
    /// Hashes the input string using SHA256 and returns the base64 string.
    /// </summary>
    /// <param name="input">The input string to hash.</param>
    /// <returns>The base64-encoded SHA256 hash of the input.</returns>
    private string Hash(string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(bytes);
    }
}
