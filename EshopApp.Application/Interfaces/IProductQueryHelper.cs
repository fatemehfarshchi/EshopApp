using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces;

/// <summary>
/// Helper interface for applying query filters to product queries.
/// </summary>
public interface IProductQueryHelper
{
    /// <summary>
    /// Applies search filters to a product query.
    /// </summary>
    /// <param name="query">The base product query.</param>
    /// <param name="search">The search string to filter products (optional).</param>
    /// <returns>The filtered product query.</returns>
    IQueryable<Product> ApplyFilters(IQueryable<Product> query, string? search);
}
