using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EshopApp.Persistence;
using System;

namespace EshopApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for managing <see cref="User"/> entities in the database.
    /// Provides CRUD operations and user-specific queries.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The application's database context.
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new <see cref="User"/> entity to the database.
        /// </summary>
        /// <param name="user">The <see cref="User"/> entity to add.</param>
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if a <see cref="User"/> exists by username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>The <see cref="User"/> entity if found; otherwise, null.</returns>
        public async Task<User?> ExistsByUserNameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        /// <summary>
        /// Retrieves a <see cref="User"/> entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>The <see cref="User"/> entity if found; otherwise, null.</returns>
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        /// <summary>
        /// Retrieves all <see cref="User"/> entities from the database.
        /// </summary>
        /// <returns>A list of all <see cref="User"/> entities.</returns>
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
