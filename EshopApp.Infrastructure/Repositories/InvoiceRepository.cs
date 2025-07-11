using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EshopApp.Persistence;
using System;
using EshopApp.Application.DTOs;




namespace EshopApp.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for managing invoice entities in the database.
    /// </summary>
    public class InvoiceRepository : IInvoiceRepository
    {
        /// <summary>
        /// The application's database context.
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceRepository"/> class.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all invoices, including their items, from the database.
        /// </summary>
        /// <returns>A collection of all invoices.</returns>
        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices
                .Include(i => i.Items)
                .ToListAsync();
        }

        /// <summary>
        /// Adds a new invoice to the database and saves changes.
        /// </summary>
        /// <param name="invoice">The invoice to add.</param>
        public async Task AddAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an invoice and its items from the database by ID.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice to delete.</param>
        public async Task DeleteAsync(Guid id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice is null)
                throw new Exception("Invoice not found");

            _context.InvoiceItems.RemoveRange(invoice.Items);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing invoice in the database and saves changes.
        /// </summary>
        /// <param name="invoice">The invoice to update.</param>
        public async Task UpdateAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves an invoice by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice.</param>
        /// <returns>The invoice if found; otherwise, null.</returns>
        public async Task<Invoice?> GetByIdAsync(Guid id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        /// <summary>
        /// Retrieves filtered invoices based on customer ID and date range.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer (optional).</param>
        /// <param name="fromDate">The start date for filtering (optional).</param>
        /// <param name="toDate">The end date for filtering (optional).</param>
        /// <returns>A list of filtered invoices.</returns>
        public async Task<List<Invoice>> GetFilteredAsync(Guid? customerId, DateTime? fromDate, DateTime? toDate)
        {
            var query = _context.Invoices
                .Include(i => i.Items)
                .AsQueryable();

            if (customerId.HasValue)
                query = query.Where(i => i.CustomerId == customerId.Value);

            if (fromDate.HasValue)
                query = query.Where(i => i.Date >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(i => i.Date <= toDate.Value);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Retrieves the total invoice information for a specific customer.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>The <see cref="CustomerTotalInvoiceDto"/> for the customer, or null if not found.</returns>
        public async Task<CustomerTotalInvoiceDto?> GetCustomerTotalInvoiceAsync(Guid customerId)
        {
            var invoices = await _context.Invoices
                .Include(i => i.Items)
                .Where(i => i.CustomerId == customerId)
                .ToListAsync();

            if (!invoices.Any()) return null;

            var total = invoices.Sum(i => i.Items.Sum(it => it.UnitPrice * it.Quantity));
            return new CustomerTotalInvoiceDto
            {
                CustomerId = customerId,
                InvoiceCount = invoices.Count,
                TotalAmount = total
            };
        }
    }
}