using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;

/// <summary>
/// Helper class for applying query filters to product queries.
/// </summary>
public class ProductQueryHelper : IProductQueryHelper
{
    /// <summary>
    /// Applies search filters to the product query.
    /// </summary>
    /// <param name="query">The product query to filter.</param>
    /// <param name="search">The search string to filter by product name.</param>
    /// <returns>The filtered product query.</returns>
    public IQueryable<Product> ApplyFilters(IQueryable<Product> query, string? search)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Name.Contains(search));
        }

        return query;
    }
}
