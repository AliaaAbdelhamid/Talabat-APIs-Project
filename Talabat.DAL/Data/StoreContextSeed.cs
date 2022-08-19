using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.DAL.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var BrandsData = File.ReadAllText("../Talabat.DAL/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                    foreach (var brand in brands)
                    {
                        context.Set<ProductBrand>().Add(brand);

                    }
                    await context.SaveChangesAsync();

                }
                if (!context.productTypes.Any())
                {

                    var TypesData = File.ReadAllText("../Talabat.DAL/Data/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                    foreach (var type in Types)
                    {
                        context.Set<ProductType>().Add(type);

                    }
                    await context.SaveChangesAsync();

                }
                if (!context.products.Any())
                {


                    var productsData = File.ReadAllText("../Talabat.DAL/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var product in products)
                    {
                        context.Set<Product>().Add(product);

                    }
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex, ex.Message);

            }

        }
    }
}
