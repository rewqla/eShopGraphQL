using HotChocolate.Pagination;

namespace eShop.Catalog.Services
{
    public sealed class ProductService(CatalogContext context)
    {
        public async Task<Page<Product>> GetProductsAsync(PagingArguments pagingArguments, CancellationToken cancellationToken = default)
        {
            return await context.Products.OrderBy(t => t.Name).ThenBy(t => t.Id).ToPageAsync(pagingArguments, cancellationToken);
        }

        public async Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Products.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }
    }
}
