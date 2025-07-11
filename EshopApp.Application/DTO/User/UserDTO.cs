namespace EshopApp.Application.DTO;

/// <summary>
/// Data Transfer Object (DTO) representing a user and their role.
/// </summary>
public class UserDTO
{
    /// <summary>
    /// The unique identifier of the user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The username of the user.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// The role of the user.
    /// </summary>
    public string Role { get; set; } = string.Empty;
}
