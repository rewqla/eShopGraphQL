using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;

namespace eShop.Catalog.Types;

[QueryType]
public static class ProductTypeQueries
{
    [UsePaging]
    [UseProjection]
    public static IQueryable<ProductType> GetProductTypes(CatalogContext context)
        => context.ProductTypes;

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<ProductType> GetProductTypeById(int id, CatalogContext context)
        => context.ProductTypes.Where(t => t.Id == id);
}