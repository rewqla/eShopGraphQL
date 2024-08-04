using eShop.Catalog.Extensions;
using eShop.Catalog.Services;
using eShop.Catalog.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<CatalogContext>(
        o => o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services
    .AddMigration<CatalogContext, CatalogContextSeed>();

builder.Services
    .AddScoped<ProductService>()
    .AddScoped<BrandService>()
    .AddScoped<ProductTypeService>();

builder.Services
    .AddGraphQLServer()
    .AddCatalogTypes()
    .AddGraphQLConventions()
    .AddErrorInterfaceType<IMyErrorInterface>()
    .AddErrorFilter(error =>
    {
        if (error.Exception is ThisIsNiceException ex)
        {
            var errorBuilder = ErrorBuilder.FromError(error);
            errorBuilder.SetMessage("This is a new message.");
            errorBuilder.SetExtension("kind", ex.GetType().Name);
            errorBuilder.SetExtension("somethingUseful", ex.SomethingUseful);
            return errorBuilder.Build();
        }

        return error;
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnonymous", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseCors("AllowAnonymous");

app.MapGraphQL();

app.RunWithGraphQLCommands(args);

public interface IMyErrorInterface
{
    string Message { get; }
}