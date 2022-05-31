using System.Net.Mime;
using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MakeUpShop.SeedData;

public static class SeedData
{
    public static void ScriptToCreateDBData(IServiceProvider serviceProvider)
    {
        using (var context =
               new ApplicationContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
        {
            var categoties = new List<Category>
            {
                new Category { Name = "Одяг" },
                new Category { Name = "Дитячі товари" },
                new Category { Name = "Товари для тварин" },
                new Category { Name = "Іжа" }
            };

            var products = new List<Product>
            {
                new Product{Name = "Яловичина консерва", Category = categoties[3], Price = 80,ImageUrl = "/img/products/beaf.jpg", IsAvailable = true},
                new Product{Name = "Куряча консерва", Category = categoties[3],Price = 60, ImageUrl = "/img/products/chicken.jpg", IsAvailable = true},
                new Product{Name = "Коляска Chicco Urban", Category = categoties[1], Price = 500,ImageUrl = "/img/products/chicco_urban.jpg", IsAvailable = true},
                new Product{Name = "Велосипед Frozen", Category = categoties[1],Price = 550, ImageUrl = "/img/products/velo_pink.jpg", IsAvailable = true},
                new Product{Name = "Корм для собаки Flora", Category = categoties[2],Price = 120, ImageUrl = "/img/products/dog_food_flora.jpg", IsAvailable = true},
                new Product{Name = "Переноска для тварин", Category = categoties[2],Price = 255, ImageUrl = "/img/products/perenoska.jpg", IsAvailable = true},
                new Product{Name = "Футболка чорна", Category = categoties[0],Price = 180, ImageUrl = "/img/products/shirt1.jpg", IsAvailable = true},
                new Product{Name = "Джинси сірі", Category = categoties[0],Price = 360, ImageUrl = "/img/products/jeans.png", IsAvailable = true}
            };


            context.Categories.AddRange(categoties);
            context.Products.AddRange(products);
            context.SaveChanges();
        }

    }

    public static async Task ScriptToCreateIdentityDBAsync(IServiceProvider serviceProvider, IRoleService roleService)
    {
        using (var context = new IdentityContext(serviceProvider.GetRequiredService<DbContextOptions<IdentityContext>>()))
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole{Name = "admin"},
                new IdentityRole{Name = "volunteer"},
                new IdentityRole{Name = "refugee"}
            };
            bool create;
            foreach (var role in roles)
            {
                create = await roleService.IsRoleCreated(role.Name);
            }
        }
    }
}