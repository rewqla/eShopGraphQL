using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;

namespace eShop.Catalog.Types;

[QueryType]
public static class BrandQueries
{
    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)]
    [UseProjection]
    public static IQueryable<Brand> GetBrands(CatalogContext context)
        => context.Brands;

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<Brand> GetBrandById(int id, CatalogContext context)
        => context.Brands.Where(t => t.Id == id);
}