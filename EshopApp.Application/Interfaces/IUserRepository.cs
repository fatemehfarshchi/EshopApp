using EshopApp.Domain.Entities;

/// <summary>
/// Repository interface for managing user entities in the data store.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Adds a new user to the data store.
    /// </summary>
    /// <param name="user">The user entity to add.</param>
    Task AddAsync(User user);

    /// <summary>
    /// Checks if a user exists by their username.
    /// </summary>
    /// <param name="Username">The username to check for existence.</param>
    /// <returns>The user entity if found; otherwise, null.</returns>
    Task<User?> ExistsByUserNameAsync(string Username);

    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The user entity if found; otherwise, null.</returns>
    Task<User?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all users from the data store.
    /// </summary>
    /// <returns>List of all user entities.</returns>
    Task<List<User>> GetAllAsync();
}
