using Dominio;
using FluentMigrator.Runner;
using Infraestrutura;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositorioProduto, RepositorioProduto>();

builder.Services.AddLinqToDBContext<ProdutoDb>((provider, options) =>
    options
        .UsePostgreSQL(builder.Configuration.GetConnectionString("Default"))
        .UseDefaultLogging(provider));

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres()
        .WithGlobalConnectionString("Default")
        .ScanIn(typeof(_202407031950CriarTabelaDeProduto).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{

    UpdateDatabase(scope.ServiceProvider);
}

static void UpdateDatabase(IServiceProvider serviceProvider)
{
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    runner.MigrateUp();
}

app.Run();