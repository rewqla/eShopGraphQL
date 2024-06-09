using eShop.Catalog.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<CatalogContext>(
        o => o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services
    .AddMigration<CatalogContext, CatalogContextSeed>();

builder.Services.AddScoped<Query>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);