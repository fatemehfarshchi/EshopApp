/// <summary>
/// Use case for retrieving store information.
/// Fetches the store entity and maps it to a DTO for output.
/// Returns null if the store is not found.
/// </summary>
public class GetStoreInfoUseCase
{
    private readonly IStoreInfoRepository _repository;

    /// <summary>
    /// Constructor that injects the store info repository dependency.
    /// </summary>
    /// <param name="repository">The repository for store information.</param>
    public GetStoreInfoUseCase(IStoreInfoRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the retrieval operation for store information.
    /// </summary>
    /// <returns>The store info DTO if found; otherwise, null.</returns>
    public async Task<StoreInfoDto?> ExecuteAsync()
    {
        // Retrieve the store entity
        var store = await _repository.GetAsync();
        if (store == null) return null;

        // Map the entity to a DTO and return
        return new StoreInfoDto
        {
            Id = store.Id,
            Name = store.Name,
            Address = store.Address,
            Phone = store.Phone,
            Website = store.Website
        };
    }
}
