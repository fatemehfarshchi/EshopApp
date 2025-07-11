using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EshopApp.Persistence;
using System;



namespace EshopApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for managing customer entities in the database.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// The application's database context.
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a customer by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>The customer if found; otherwise, null.</returns>
        public async Task<Customer?> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        /// <summary>
        /// Adds a new customer to the database and saves changes.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if a customer with the specified name exists in the database.
        /// </summary>
        /// <param name="name">The name of the customer to check.</param>
        /// <returns>True if a customer with the name exists; otherwise, false.</returns>
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Customers.AnyAsync(c => c.Name == name);
        }

        /// <summary>
        /// Retrieves all customers, including their products and product categories, from the database.
        /// </summary>
        /// <returns>A collection of all customers.</returns>
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
                                 .Include(c => c.Products)
                                 .ThenInclude(P => P.Category)
                                 .ToListAsync();
        }

        /// <summary>
        /// Deletes a customer from the database by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to delete.</param>
        public async Task DeleteAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new Exception("customer not find");
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing customer in the database and saves changes.
        /// </summary>
        /// <param name="customer">The customer to update.</param>
        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}