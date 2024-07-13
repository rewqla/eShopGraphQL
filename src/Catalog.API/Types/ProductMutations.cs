using eShop.Catalog.Services;
using eShop.Catalog.Types.Errors;
using eShop.Catalog.Types.Inputs;

namespace eShop.Catalog.Types
{
    [MutationType]
    public static class ProductMutations
    {
        [Error<InvalidBrandIdErrorFactory>]
        [Error<InvalidProductTypeIdError>]
        [Error<ArgumentException>]
        [Error<MaxStockThresholdToSmallException>]
        public static async Task<Product> CreateProductAsync(
        CreateProductInput input,
        ProductService productService,
        CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                TypeId = input.TypeId,
                BrandId = input.BrandId,
                RestockThreshold = input.RestockThreshold,
                MaxStockThreshold = input.MaxStockThreshold
            };

            await productService.CreateProductAsync(product, cancellationToken);

            return product;
        }
    }
}
