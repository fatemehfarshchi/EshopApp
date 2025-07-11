namespace EshopApp.Application.DTO;

/// <summary>
/// Data Transfer Object (DTO) representing the result of a user login operation.
/// </summary>
public class LoginResultDTO
{
    /// <summary>
    /// The unique identifier of the logged-in user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The username of the logged-in user.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// The role of the logged-in user.
    /// </summary>
    public string Role { get; set; } = string.Empty;
}
