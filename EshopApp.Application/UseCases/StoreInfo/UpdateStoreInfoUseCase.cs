/// <summary>
/// Use case for updating store information.
/// Retrieves the store by ID, updates its properties from the provided DTO,
/// and persists the changes using the repository.
/// Throws an exception if the store is not found.
/// </summary>
public class UpdateStoreInfoUseCase
{
    private readonly IStoreInfoRepository _repository;

    /// <summary>
    /// Constructor that injects the store info repository dependency.
    /// </summary>
    /// <param name="repository">The repository for store information.</param>
    public UpdateStoreInfoUseCase(IStoreInfoRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the update operation for store information.
    /// </summary>
    /// <param name="dto">The data transfer object containing updated store info.</param>
    /// <returns>True if the update is successful.</returns>
    /// <exception cref="Exception">Thrown if the store info is not found.</exception>
    public async Task<bool> ExecuteAsync(StoreInfoDto dto)
    {

        // Retrieve the store entity by its ID
        var store = await _repository.GetByIdAsync(dto.Id);
        if (store == null)
            throw new Exception("Store info not found.");

        // Update store properties from the DTO
        store.Name = dto.Name;
        store.Address = dto.Address;
        store.Phone = dto.Phone;
        store.Website = dto.Website;

        // Persist the updated store entity
        await _repository.UpdateAsync(store);
        return true;
    }
}
