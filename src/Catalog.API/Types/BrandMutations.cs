using eShop.Catalog.Services;

namespace eShop.Catalog.Types;

[MutationType]
public static class BrandMutations
{
    public static async Task<CreateBrandPayload> CreateBrandAsync(
        CreateBrandInput input,
        BrandService brandService,
        CancellationToken cancellationToken)
    {
        var brand = new Brand { Name = input.Name };
        await brandService.CreateBrandAsync(brand, cancellationToken);
        return new CreateBrandPayload(brand);
    }
}

public record CreateBrandInput(string Name);
public record CreateBrandPayload(Brand Brand);