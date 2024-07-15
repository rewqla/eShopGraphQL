using eShop.Catalog.Services;

namespace eShop.Catalog.Types.Filtering;

public readonly record struct ProductsFilterInputType(
    ProductsBrandIdFilterInputType? BrandId,
    ProductsTypeIdFilterInputType? TypeId,
    string Name,
    decimal Price)
{
    public ProductFilter ToFilter() => new(Name, Price, BrandId?.In, TypeId?.In);
}

public readonly record struct ProductsBrandIdFilterInputType(int[]? In);

public readonly record struct ProductsTypeIdFilterInputType(int[]? In);