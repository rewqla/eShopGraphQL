using eShop.Catalog.Types.Filtering;
using HotChocolate.Execution.Configuration;

namespace eShop.Catalog.Extensions
{
    public static class CustomRequestExecutorBuilderExtensions
    {
        public static IRequestExecutorBuilder AddGraphQLConventions(
            this IRequestExecutorBuilder builder)
        {
            builder.AddPagingArguments();
            builder.AddFiltering(
                    c => c.AddDefaults()
                        .BindRuntimeType<string, DefaultStringOperationFilterInputType>());
            builder.AddType<ProductFilterInputType>();
            builder.AddSorting();
            builder.AddGlobalObjectIdentification();
            builder.AddQueryConventions();
            builder.AddMutationConventions();

            return builder;
        }
    }
}
