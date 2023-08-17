using API.Controllers;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.DataStore;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ShoppingConnectionString");
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
builder.Services.AddDbContext<ShopContext>(options =>
options.UseSqlite(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//database migration setup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerfactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<ShopContext>();
        await context.Database.MigrateAsync();
        await ShopContextSeed.SeedAsync(context, loggerfactory);
    }
    catch (Exception ex)
    {
        var logger = loggerfactory.CreateLogger<Program>();
        logger.LogError(ex, "Migration failed");
    }

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
