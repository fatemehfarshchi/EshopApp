using EshopApp.Application.DTO;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.UseCases;

/// <summary>
/// Use case for creating new store information in the system.
/// </summary>
public class CreateStoreInfoUseCase
{
    /// <summary>
    /// The repository for accessing and creating store information data.
    /// </summary>
    private readonly IStoreInfoRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateStoreInfoUseCase"/> class.
    /// </summary>
    /// <param name="repository">The store info repository dependency.</param>
    public CreateStoreInfoUseCase(IStoreInfoRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Creates new store information using the provided DTO.
    /// </summary>
    /// <param name="dto">The DTO containing store information.</param>
    /// <returns>The unique identifier of the newly created store information.</returns>
    public async Task<Guid> ExecuteAsync(StoreInfoDto dto)
    {
        // Create the store information entity
        var storeInfo = new StoreInfo
        {
            Name = dto.Name,
            Address = dto.Address,
            Phone = dto.Phone
        };

        // Add the new store information to the repository
        await _repository.CreateAsync(storeInfo);
        return storeInfo.Id;
    }
}
