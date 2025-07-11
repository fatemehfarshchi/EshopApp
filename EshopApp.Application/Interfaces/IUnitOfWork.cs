using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces;

/// <summary>
/// Unit of Work interface for coordinating repository operations and saving changes as a single transaction.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets the invoice repository.
    /// </summary>
    IInvoiceRepository InvoiceRepository { get; }

    /// <summary>
    /// Gets the invoice item repository.
    /// </summary>
    IInvoiceItemRepository InvoiceItemRepository { get; }

    /// <summary>
    /// Gets the product repository.
    /// </summary>
    IProductRepository ProductRepository { get; }

    /// <summary>
    /// Gets the customer repository.
    /// </summary>
    ICustomerRepository CustomerRepository { get; }

    /// <summary>
    /// Gets the category repository.
    /// </summary>
    ICategoryRepository CategoryRepository { get; }

    /// <summary>
    /// Saves all changes made in the unit of work to the data store.
    /// </summary>
    /// <returns>The number of state entries written to the data store.</returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Adds a new product to the data store.
    /// </summary>
    /// <param name="product">The product entity to add.</param>
    Task AddAsync(Product product);

    /// <summary>
    /// Checks if a product exists by its name.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <returns>True if the product exists; otherwise, false.</returns>
    Task<bool> ExistsByNameAsync(string name);
}
