namespace eShop.Catalog.Services
{
    public class BrandService(CatalogContext context)
    {
        public static IQueryable<Brand> GetBrands(CatalogContext context)
            => context.Brands;

        public async Task<Brand?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Brands.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }
    }
}
