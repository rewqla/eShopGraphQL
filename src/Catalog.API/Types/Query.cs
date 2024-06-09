namespace eShop.Catalog.Types
{
    public class Query
    {
        [UsePaging]
        //[UsePaging(DefaultPageSize = 1, MaxPageSize = 20)]
        [UseProjection]    //For nested classes
        public IQueryable<Product> GetProducts(CatalogContext context)
            => context.Products;

        [UseFirstOrDefault]
        //For nested classes and need to be used via where
        [UseProjection]
        public IQueryable<Product?> GetProductById(int id, CatalogContext context)
            => context.Products.Where(p => p.Id == id);
    }
}
