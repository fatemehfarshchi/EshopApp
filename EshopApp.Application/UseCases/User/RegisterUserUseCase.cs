using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using EshopApp.Application.DTO;
using System.Security.Cryptography;


/// <summary>
/// Use case for registering a new user in the system.
/// </summary>
public class RegisterUserUseCase
{
    /// <summary>
    /// The repository for accessing and adding user data.
    /// </summary>
    private readonly IUserRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUserUseCase"/> class.
    /// </summary>
    /// <param name="repository">The user repository dependency.</param>
    public RegisterUserUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Registers a new user using the provided DTO.
    /// </summary>
    /// <param name="dto">The DTO containing new user information.</param>
    /// <exception cref="Exception">Thrown if the user already exists or if required fields are missing.</exception>
    public async Task ExecuteAsync(RegisterUserDTO dto)
    {
        // Check if a user with the same username already exists
        var exists = await _repository.ExistsByUserNameAsync(dto.UserName);

        if (exists != null)
            throw new Exception("User already exists");
        
        // Validate required fields
        if (string.IsNullOrWhiteSpace(dto.UserName) || string.IsNullOrWhiteSpace(dto.Password))
            throw new Exception("UserName and PassWord must not be NULL");

        // Hash the user's password
        var passwordHash = Hash(dto.Password);

        // Create the new user entity
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            UserName = dto.UserName,
            Email = dto.Email,
            PasswordHash = passwordHash,
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
