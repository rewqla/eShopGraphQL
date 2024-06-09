namespace eShop.Catalog.Types
{
    public class Query
    {
        //For nested classes
        [UseProjection]
        public IQueryable<Product> GetProducts(CatalogContext context)
            => context.Products;
        
        [UseFirstOrDefault]
        //For nested classes and need to be used via where
        [UseProjection]
        public IQueryable<Product?> GetProductById(int id, CatalogContext context)
            => context.Products.Where(p => p.Id == id);
    }
}
