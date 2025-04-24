using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class DBInitializer(StoreDbContext context) : IDbInitilizer
    {
        public async Task InitializerAsync()
        {
            if ((await context.Database.GetAppliedMigrationsAsync()).Any())
            {
                await context.Database.MigrateAsync();

            }

            if (!context.Set<ProductBrand>().Any())
            {
                var data = await File.ReadAllTextAsync(@"../Infrastructure/Persistence/Data/Seeds/brands.json");
                var objects = JsonSerializer.Deserialize<List<ProductBrand>>(data);

                if(objects != null && objects.Any())
                {
                    context.Set<ProductBrand>().AddRange(objects);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<ProductType>().Any())
            {
                var data = await File.ReadAllTextAsync(@"../Infrastructure/Persistence/Data/Seeds/types.json");
                var objects = JsonSerializer.Deserialize<List<ProductType>>(data);

                if (objects != null && objects.Any())
                {
                    context.Set<ProductType>().AddRange(objects);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<Products>().Any())
            {
                var data = await File.ReadAllTextAsync(@"../Infrastructure/Persistence/Data/Seeds/Products.json");
                var objects = JsonSerializer.Deserialize<List<Products>>(data);

                if (objects != null && objects.Any())
                {
                    context.Set<Products>().AddRange(objects);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
