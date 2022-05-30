using System.Net.Mime;
using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MakeUpShop.SeedData;

public static class SeedData
{
    //public static void ScriptToCreateDBData(IServiceProvider serviceProvider)
    //{
    //    using (var context = new ApplicationContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>()))
    //    {
    //        var images = new List<MediaTypeNames.Image>
    //        {
    //            //ProductNomenclatures
    //            new MediaTypeNames.Image {Name = "armani-my-way.png", Url = "/img/products/armani-my-way.png"},
    //            new MediaTypeNames.Image {Name = "chanel-gabrielle.png", Url = "/img/products/chanel-gabrielle.png"},
    //            new MediaTypeNames.Image {Name = "carolina-herrera-good-girl.png", Url = "/img/products/carolina-herrera-good-girl.png"},
    //        };


    //        var brands = new List<Brand>
    //                {
    //                    new Brand {Name = "Armani", City = "Milan", ImageUrl = "/img/brands/Armani.png"},
    //                    new Brand {Name ="Chanel", City = "Paris", ImageUrl = "/img/brands/Chanel.png"},
    //                    new Brand{Name = "Carolina Herrera",City = "New York City", ImageUrl = "/img/brands/Carolina Herrera.png"}
    //                };

    //        var types = new List<TypeProduct>
    //                {
    //                    new TypeProduct {Name = "pafum water"}
    //                };
    //        var filters = new List<Filter>
    //                {
    //                    new Filter {Name = "For her"}
    //                };
    //        var bottles = new List<Bottle>
    //                {
    //                    new Bottle {ContainerSize = "мл"}
    //                };
    //        var productNames = new List<ProductName>
    //                {
    //                    new ProductName{Name = "My Way"},
    //                    new ProductName{Name = "Chanel Gabrielle"},
    //                    new ProductName{Name = "Carolina Herrera"}
    //                };
    //        var products = new List<Product>
    //        {
    //            new Product
    //            {
    //                ProductName = productNames[0], Country = Country.Italy, Brand = brands[0], Type = types[0],
    //                Sum = 2458, ProductAmounts = 30, Bottle = bottles[0], ProductInStocks = 100
    //            },
    //            new Product
    //            {
    //                ProductName = productNames[0], Country = Country.Italy, Brand = brands[0], Type = types[0],
    //                Sum = 3497, ProductAmounts = 50, Bottle = bottles[0], ProductInStocks = 100
    //            },
    //            new Product
    //            {
    //                ProductName = productNames[1], Country = Country.France, Brand = brands[1], Type = types[0],
    //                Sum = 2597, ProductAmounts = 35, Bottle = bottles[0], ProductInStocks = 50
    //            },
    //            new Product
    //            {
    //                ProductName = productNames[2], Country = Country.USA, Brand = brands[2], Type = types[0],
    //                Sum = 5470, ProductAmounts = 30, Bottle = bottles[0], ProductInStocks = 150
    //            }
    //        };


    //        products[0].Images.Add(images[0]);
    //        products[1].Images.Add(images[0]);
    //        products[2].Images.Add(images[1]);
    //        products[3].Images.Add(images[2]);
            
    //        context.Images.AddRange(images);
    //        //context.BrandImages.AddRange(brandImages);
    //        context.Brands.AddRange(brands);
    //        context.TypeProducts.AddRange(types);
    //        context.Filters.AddRange(filters);
    //        context.Products.AddRange(products);
    //        context.ProductNames.AddRange(productNames);
    //        context.Bottles.AddRange(bottles);

    //        context.SaveChanges();
    //    }

    //}

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