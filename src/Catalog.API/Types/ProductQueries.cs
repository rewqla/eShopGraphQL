using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;

namespace eShop.Catalog.Types;

[QueryType]
public static class ProductQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Product> GetProducts(CatalogContext context, IFilterContext filterContext, ISortingContext sortingContext)
    {
        filterContext.Handled(false);
        sortingContext.Handled(false);

        IQueryable<Product> query = context.Products;

        if (!filterContext.IsDefined)
        {
            query = query.Where(t => t.BrandId == 1);
        }

        if (!sortingContext.IsDefined)
        {
            query = query.OrderBy(t => t.Brand!.Name).ThenByDescending(t => t.Price);
        }

        return query;
    }

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<Product> GetProductById(int id, CatalogContext context)
        => context.Products.Where(t => t.Id == id);
}