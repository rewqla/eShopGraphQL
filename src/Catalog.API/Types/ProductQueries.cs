using System.Buffers;
using eShop.Catalog.Services;
using eShop.Catalog.Types.Filtering;
using eShop.Catalog.Types.Sorting;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Pagination;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;

namespace eShop.Catalog.Types;

[QueryType]
public static class ProductQueries
{
    //[UsePaging]
    //public static async Task<Connection<Product>> GetProductsAsync(
    //    ProductsFilterInputType? where,
    //    PagingArguments pagingArguments,
    //    ProductService productService,
    //    CancellationToken cancellationToken)
    //    => await productService.GetProductsAsync(where?.ToFilter(), pagingArguments, cancellationToken).ToConnectionAsync();


    [UseOffsetPaging(MaxPageSize = 10, IncludeTotalCount = true)]
    //[UsePaging(MaxPageSize = 10)]
    [UseFiltering(typeof(ProductFilterInputType))]
    [UseSorting(typeof(ProductSortInputType))]
    public static async Task<IList<Product>> GetProductsAsync(
    ProductService productService,
    CancellationToken cancellationToken)
    {
        return await productService.GetProductsAsync(cancellationToken);
    }



    [Error<CustomError>]
    [NodeResolver]
    public static async Task<Product?> GetProductByIdAsync(
        int id,
        ProductService productService,
        CancellationToken cancellationToken)
        => await productService.GetProductByIdAsync(id, cancellationToken);
}

public class CustomError : IMyErrorInterface
{
    private readonly CustomException _exception;

    public CustomError(CustomException exception)
    {
        _exception = exception;
    }

    public string Message => "This is a safe message";

    public int Id => _exception.Id;
}

public record IdNotValid(int Id)
{
    public string Message => "Invalid Id Structure";
}

public interface INodeIdSerializer
{
    void Format(object id, IBufferWriter<byte> output);

    object Parse(ReadOnlySpan<byte> value);
}