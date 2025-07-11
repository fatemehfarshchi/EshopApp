namespace EshopApp.Application.DTO;

/// <summary>
/// Data Transfer Object (DTO) for registering a new user by an admin.
/// </summary>
public class RegisterUserByAdminDto
{
    /// <summary>
    /// The username of the admin performing the registration.
    /// </summary>
    public string AdminUserName { get; set; } = string.Empty; 

    /// <summary>
    /// The username of the new user to be registered.
    /// </summary>
    public string NewUserName { get; set; } = string.Empty;   

    /// <summary>
    /// The password for the new user.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The role to assign to the new user.
    /// </summary>
    public string Role { get; set; } = string.Empty; 
}
