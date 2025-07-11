using EshopApp.Application.DTO;
/// <summary>
/// Use case for retrieving all users from the system.
/// </summary>
public class GetUserUseCase
{
    /// <summary>
    /// The repository for accessing user data.
    /// </summary>
    private readonly IUserRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetUserUseCase"/> class.
    /// </summary>
    /// <param name="repository">The user repository dependency.</param>
    public GetUserUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Retrieves all users from the repository and maps them to DTOs.
    /// </summary>
    /// <returns>A list of <see cref="UserDTO"/> objects representing all users.</returns>
    public async Task<List<UserDTO>> ExecuteAsync()
    {
        // Fetch all users from the repository
        var users = await _repository.GetAllAsync();
        // Map each user to a DTO
        return users.Select(u => new UserDTO
        {
            Id = u.Id,
            UserName = u.UserName,
            Role = u.Role
        }).ToList();
    }
}
