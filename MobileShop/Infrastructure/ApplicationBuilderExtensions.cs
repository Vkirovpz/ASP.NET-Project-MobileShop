namespace MobileShop.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using MobileShop.Data;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using MobileShop.Data.Entities;
    using System;
    using Microsoft.AspNetCore.Identity;
    using static MobileShop.Areas.Admin.AdminConstants;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase (this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            Migratedatabase(services);
            SeedBrands(services);
            SeedCategories(services);
            SeedAdministrator(services);

            return app;
        }

        private static void Migratedatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<MobileShopDbContext>();

            data.Database.Migrate();
        }
        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<MobileShopDbContext>();

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

        private static void SeedBrands(IServiceProvider services)
        {
            var data = services.GetRequiredService<MobileShopDbContext>();

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

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }
                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@phones.com";
                    const string adminPassword = "admin123";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FullName = "Admin"
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);

                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
