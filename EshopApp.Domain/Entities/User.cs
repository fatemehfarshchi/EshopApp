using EshopApp.Shared;

namespace EshopApp.Domain.Entities;

/// <summary>
/// Represents a user entity, including credentials, role, and creation date.
/// </summary>
public class User 
{
    /// <summary>
    /// The unique identifier for the user.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The full name of the user.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The username used for login.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The hashed password for the user.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// The role of the user (e.g., Admin, Seller).
    /// </summary>
    public string Role { get; set; } = "Seller";

    /// <summary>
    /// The date and time when the user was created.
    /// </summary>
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
