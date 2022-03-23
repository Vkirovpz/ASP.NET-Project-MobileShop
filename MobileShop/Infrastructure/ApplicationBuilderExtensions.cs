namespace MobileShop.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using MobileShop.Data;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using MobileShop.Data.Entities;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase (this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<MobileShopDbContext>();

            data.Database.Migrate();

            SeedBrands(data);
            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(MobileShopDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Low-End"},
                new Category { Name = "Mid-Range"},
                new Category { Name = "High-End"},
            });

            data.SaveChanges();
        }

        private static void SeedBrands(MobileShopDbContext data)
        {
            if (data.Brands.Any())
            {
                return;
            }

            data.Brands.AddRange(new[]
            {
                new Brand { Name = "Apple"},
                new Brand { Name = "Samsung"},
                new Brand { Name = "Huawei"},
                new Brand { Name = "Xiaomi"},
                new Brand { Name = "OnePlus"},
                new Brand { Name = "BlackBerry"},
                new Brand { Name = "Sony"},
                new Brand { Name = "Nokia"},
                new Brand { Name = "Motorola"},
                new Brand { Name = "Cat"},
                new Brand { Name = "Htc"},
            });

            data.SaveChanges();
        }
    }
}
