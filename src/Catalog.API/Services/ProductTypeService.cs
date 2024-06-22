namespace eShop.Catalog.Services
{
    public class ProductTypeService(CatalogContext context)
    {
        public async Task<ProductType?> GetProductTypeByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.ProductTypes.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }
    }
}
