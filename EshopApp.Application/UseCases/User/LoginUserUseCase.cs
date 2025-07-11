using EshopApp.Application.DTO;
using EshopApp.Application.Interfaces;
using System.Security.Cryptography;


namespace EshopApp.Application.UseCases;

/// <summary>
/// Use case for authenticating a user and returning login result information.
/// </summary>
public class LoginUserUseCase
{
    /// <summary>
    /// The repository for accessing user data.
    /// </summary>
    private readonly IUserRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginUserUseCase"/> class.
    /// </summary>
    /// <param name="repository">The user repository dependency.</param>
    public LoginUserUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Authenticates the user using the provided login DTO.
    /// </summary>
    /// <param name="dto">The DTO containing login credentials.</param>
    /// <returns>A <see cref="LoginResultDTO"/> if authentication is successful; otherwise, null.</returns>
    public async Task<LoginResultDTO?> ExecuteAsync(LoginDTO dto)
    {
        // Check if the user exists by username
        var user = await _repository.ExistsByUserNameAsync(dto.UserName);
        if (user == null)
            return null;

        // Hash the provided password and compare with stored hash
        var hashedPassword = Hash(dto.Password);
        if (user.PasswordHash != hashedPassword)
            return null;

        // Return login result DTO if authentication is successful
        return new LoginResultDTO
        {
            Id = user.Id,
            UserName = user.UserName,
            Role = user.Role
        };
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
