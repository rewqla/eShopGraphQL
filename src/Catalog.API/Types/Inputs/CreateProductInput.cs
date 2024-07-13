namespace eShop.Catalog.Types.Inputs;

public record CreateProductInput(
    string Name,
    string? Description,
    decimal Price,
    [ID<ProductType>] int TypeId,
    [ID<Brand>] int BrandId,
    int RestockThreshold,
    int MaxStockThreshold);