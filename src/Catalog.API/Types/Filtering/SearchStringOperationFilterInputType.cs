using HotChocolate.Data.Filters;

namespace eShop.Catalog.Types.Filtering;

public sealed class SearchStringOperationFilterInputType : StringOperationFilterInputType
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultFilterOperations.Equals).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.NotEquals).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.StartsWith).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.NotStartsWith).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.Contains).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.NotContains).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.In).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.NotIn).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.EndsWith).Type<StringType>();
        descriptor.Operation(DefaultFilterOperations.NotEndsWith).Type<StringType>();
    }
}