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
            builder.AddFiltering();
            builder.AddSorting();
            builder.AddGlobalObjectIdentification();
            builder.AddQueryConventions();
            builder.AddMutationConventions();

            return builder;
        }
    }
}
