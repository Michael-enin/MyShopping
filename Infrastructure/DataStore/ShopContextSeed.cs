using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DataStore
{
    public class ShopContextSeed
    {
        public static async Task SeedAsync(ShopContext context, ILoggerFactory loggerFactory)
        {
            try
            {


                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/DataStore/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/DataStore/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var type in types)
                    {
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/DataStore/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var brand in brands)
                    {
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "Data seeding failed");
                var logger = loggerFactory.CreateLogger<ShopContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
