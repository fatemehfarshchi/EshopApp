using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EshopApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for managing store information entities in the database.
    /// </summary>
    public class StoreInfoRepository : IStoreInfoRepository
    {
        /// <summary>
        /// The application's database context.
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreInfoRepository"/> class.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public StoreInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves the first store information entity from the database.
        /// </summary>
        /// <returns>The first <see cref="StoreInfo"/> entity if found; otherwise, null.</returns>
        public async Task<StoreInfo?> GetAsync()
        {
            return await _context.StoreInfos.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Updates an existing store information entity in the database and saves changes.
        /// </summary>
        /// <param name="storeInfo">The store information entity to update.</param>
        public async Task UpdateAsync(StoreInfo storeInfo)
        {
            _context.StoreInfos.Update(storeInfo);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a new store information entity in the database and saves changes.
        /// </summary>
        /// <param name="storeInfo">The store information entity to create.</param>
        public async Task CreateAsync(StoreInfo storeInfo)
        {
            _context.StoreInfos.Add(storeInfo);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a store information entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the store information entity.</param>
        /// <returns>The <see cref="StoreInfo"/> entity if found; otherwise, null.</returns>
        public async Task<StoreInfo?> GetByIdAsync(Guid id)
        {
            return await _context.StoreInfos.FindAsync(id);
        }
    }
}
