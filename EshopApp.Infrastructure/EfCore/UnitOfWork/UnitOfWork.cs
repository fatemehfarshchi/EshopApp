using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EshopApp.Infrastructure.EFCore.UnitOfWork;

/// <summary>
/// Implements the Unit of Work pattern for managing repositories and database operations.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// The application's database context.
    /// </summary>
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class with all required repositories.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    /// <param name="invoiceRepo">The invoice repository.</param>
    /// <param name="itemRepo">The invoice item repository.</param>
    /// <param name="productRepo">The product repository.</param>
    /// <param name="customerRepo">The customer repository.</param>
    /// <param name="categoryRepo">The category repository.</param>
    public UnitOfWork(AppDbContext context,
        IInvoiceRepository invoiceRepo,
        IInvoiceItemRepository itemRepo,
        IProductRepository productRepo,
        ICustomerRepository customerRepo,
        ICategoryRepository categoryRepo)
    {
        _context = context;
        InvoiceRepository = invoiceRepo;
        InvoiceItemRepository = itemRepo;
        ProductRepository = productRepo;
        CustomerRepository = customerRepo;
        CategoryRepository = categoryRepo;
    }

    /// <summary>
    /// Gets the invoice repository.
    /// </summary>
    public IInvoiceRepository InvoiceRepository { get; }
    /// <summary>
    /// Gets the invoice item repository.
    /// </summary>
    public IInvoiceItemRepository InvoiceItemRepository { get; }
    /// <summary>
    /// Gets the product repository.
    /// </summary>
    public IProductRepository ProductRepository { get; }
    /// <summary>
    /// Gets the customer repository.
    /// </summary>
    public ICustomerRepository CustomerRepository { get; }
    /// <summary>
    /// Gets the category repository.
    /// </summary>
    public ICategoryRepository CategoryRepository { get; }

    /// <summary>
    /// Saves all changes made in the context to the database.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

    /// <summary>
    /// Adds a new product to the database and saves changes.
    /// </summary>
    /// <param name="product">The product to add.</param>
    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns>The product if found; otherwise, null.</returns>
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    /// <summary>
    /// Checks if a product with the specified name exists in the database.
    /// </summary>
    /// <param name="name">The name of the product to check.</param>
    /// <returns>True if a product with the name exists; otherwise, false.</returns>
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Products.AnyAsync(c => c.Name == name);
    }
}
