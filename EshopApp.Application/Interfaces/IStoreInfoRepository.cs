using EshopApp.Domain.Entities;

/// <summary>
/// Repository interface for managing store information entities in the data store.
/// </summary>
public interface IStoreInfoRepository
{
    /// <summary>
    /// Retrieves the store information.
    /// </summary>
    /// <returns>The store information entity if found; otherwise, null.</returns>
    Task<StoreInfo?> GetAsync();

    /// <summary>
    /// Updates the store information in the data store.
    /// </summary>
    /// <param name="storeInfo">The store information entity with updated data.</param>
    Task UpdateAsync(StoreInfo storeInfo);

    /// <summary>
    /// Creates new store information in the data store.
    /// </summary>
    /// <param name="storeInfo">The store information entity to create.</param>
    Task CreateAsync(StoreInfo storeInfo);

    /// <summary>
    /// Retrieves the store information by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the store information.</param>
    /// <returns>The store information entity if found; otherwise, null.</returns>
    Task<StoreInfo?> GetByIdAsync(Guid id);
}
