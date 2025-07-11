namespace EshopApp.Application.DTO;

/// <summary>
/// Data Transfer Object (DTO) for registering a new user.
/// </summary>
public class RegisterUserDTO
{
    /// <summary>
    /// The username of the new user.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// The full name of the new user.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the new user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The password for the new user.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
