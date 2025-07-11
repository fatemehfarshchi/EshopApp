using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EshopApp.Persistence;
using System;
using EshopApp.Application.DTO;



namespace EshopApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for managing invoice item entities in the database.
    /// </summary>
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        /// <summary>
        /// The application's database context.
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceItemRepository"/> class.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public InvoiceItemRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a range of invoice items to the database and saves changes.
        /// </summary>
        /// <param name="items">The list of invoice items to add.</param>
        public async Task AddRangeAsync(List<InvoiceItem> items)
        {
            await _context.InvoiceItems.AddRangeAsync(items);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an invoice item from the database by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice item to delete.</param>
        public async Task DeleteAsync(Guid id)
        {
            var invoiceitem = await _context.InvoiceItems.FindAsync(id);
            if (invoiceitem == null)
            {
                throw new Exception("invoiceitem not find");
            }
            _context.InvoiceItems.Remove(invoiceitem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing invoice item in the database and saves changes.
        /// </summary>
        /// <param name="invoiceitem">The invoice item to update.</param>
        public async Task UpdateAsync(InvoiceItem invoiceitem)
        {
            _context.InvoiceItems.Update(invoiceitem);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves an invoice item by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice item.</param>
        /// <returns>The invoice item if found; otherwise, null.</returns>
        public async Task<InvoiceItem?> GetByIdAsync(Guid id)
        {
            return await _context.InvoiceItems.FindAsync(id);
        }

        /// <summary>
        /// Retrieves all invoice items for a given invoice ID and maps them to DTOs.
        /// </summary>
        /// <param name="invoiceId">The unique identifier of the invoice.</param>
        /// <returns>A list of <see cref="InvoiceItemDTO"/> objects for the specified invoice.</returns>
        public async Task<List<InvoiceItemDTO>> GetInvoiceItemsByInvoiceIdAsync(Guid invoiceId)
        {
            return await _context.InvoiceItems
                .Where(i => i.InvoiceId == invoiceId)
                .Select(i => new InvoiceItemDTO
                {
                    Id = i.Id,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                })
                .ToListAsync();
        }
    }
}