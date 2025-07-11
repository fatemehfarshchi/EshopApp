namespace EshopApp.Application.DTO;

/// <summary>
/// Data Transfer Object (DTO) for user login credentials.
/// </summary>
public class LoginDTO
{
    /// <summary>
    /// The username of the user attempting to log in.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// The password of the user attempting to log in.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
