using eShop.Catalog.Models;
using HotChocolate.Data.Filters;

namespace eShop.Catalog.Types
{
    public class Query
    {
        [UsePaging(DefaultPageSize = 1, MaxPageSize = 20)]
        [UseProjection]    //For nested classes
        [UseFiltering]
        public IQueryable<Brand> GetBrands(CatalogContext context)
            => context.Brands;

        [UseFirstOrDefault]
        [UseProjection] //For nested classes and need to be used via where
        public IQueryable<Brand?> GetBrandById(int id, CatalogContext context)
            => context.Brands.Where(b => b.Id == id);


        //[UsePaging]
        [UsePaging(DefaultPageSize = 1, MaxPageSize = 20)]
        [UseProjection]    //For nested classes
        [UseFiltering]
        //[UseFiltering<ProductFilterInputType>]
        public IQueryable<Product> GetProducts(CatalogContext context)
            => context.Products;

        [UseFirstOrDefault]
        [UseProjection] //For nested classes and need to be used via where
        public IQueryable<Product?> GetProductById(int id, CatalogContext context)
            => context.Products.Where(p => p.Id == id);


        [UsePaging(DefaultPageSize = 1, MaxPageSize = 20)]
        [UseProjection]    //For nested classes
        [UseFiltering]
        public IQueryable<ProductType> GetProductTypes(CatalogContext context)
            => context.ProductTypes;

        [UseFirstOrDefault]
        [UseProjection]      //For nested classes and need to be used via where
        public IQueryable<ProductType?> GetProductTypeById(int id, CatalogContext context)
            => context.ProductTypes.Where(b => b.Id == id);
    }
}

public class ProductFilterInputType : FilterInputType<Product>
{
    protected override void Configure(IFilterInputTypeDescriptor<Product> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(t => t.Name).Type< SearchStringOperationFilterInputType>();
        descriptor.Field(t => t.Type);
        descriptor.Field(t => t.Brand);
        descriptor.Field(t => t.Price);
        descriptor.Field(t => t.AvailableStock);
        descriptor.Field(t => t.Description);
    }
}