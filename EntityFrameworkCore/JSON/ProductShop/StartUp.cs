using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProductShop
{
    public class StartUp
    {
        private static readonly string usersJson = File.ReadAllText("../../../Datasets/users.json");
        private static readonly string productsJson = File.ReadAllText("../../../Datasets/products.json");
        private static readonly string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
        private static readonly string categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
        public static void Main()
        {
            var context = new ProductShopContext();
            //ResetDatabase(context);

            //Console.WriteLine(ImportUsers(context, usersJson));
            //Console.WriteLine(ImportProducts(context, productsJson));
            //Console.WriteLine(ImportCategories(context, categoriesJson));
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsJson));

            File.WriteAllText((@"..\..\..\Datasets\users-and-products.json"), GetUsersWithProducts(context), Encoding.UTF8);
        }

        //private static void ResetDatabase(ProductShopContext context)
        //{
        //    context.Database.EnsureDeleted();
        //    Console.WriteLine("Database deleted!");

        //    context.Database.EnsureCreated();

        //    Console.WriteLine("Database Created!");
        //}

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson, jsonSettings);

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsRange = context.Products
                                       .Where(x => x.Price >= 500 && x.Price <= 1000)
                                       .OrderBy(x => x.Price)
                                       .Select(x => new
                                       {
                                           name = x.Name,
                                           price = x.Price,
                                           seller = $"{x.Seller.FirstName} {x.Seller.LastName}",
                                       })
                                       .ToList();

            var exportedJson = JsonConvert.SerializeObject(productsRange, Formatting.Indented);
            var path = @"..\..\..\Datasets";

            return exportedJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var productsWithBuyer = context.Users
                                           .Where(x => x.ProductsSold.Any(b => b.BuyerId != null))
                                           .Select(x => new
                                           {
                                               firstName = x.FirstName,
                                               lastName = x.LastName,
                                               soldProducts = x.ProductsSold
                                                               .Select(sp => new
                                                               {
                                                                   name = sp.Name,
                                                                   price = sp.Price,
                                                                   buyerFirstName = sp.Buyer.FirstName,
                                                                   buyerLastName = sp.Buyer.LastName,
                                                               })
                                           })
                                           .OrderBy(x => x.lastName)
                                           .ThenBy(x => x.firstName)
                                           .AsEnumerable();

            var exportedJson = JsonConvert.SerializeObject(productsWithBuyer, Formatting.Indented);
            return exportedJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            //var categories = context.Categories
            //                        .Select(x => new
            //                        {
            //                            Category = x.Name,
            //                            ProductsCount = x.CategoriesProducts
            //                                             .Count(),
            //                            AveragePrice = $"{x.CategoriesProducts.Average(y => y.Product.Price):f2}",
            //                            TotalRevenue = $"{x.CategoriesProducts.Sum(y => y.Product.Price):f2}",
            //                        })
            //                        .OrderByDescending(x => x.ProductsCount)
            //                        .ToList();

            var categories = context.Categories
                                   .Select(x => new
                                   {
                                       Category = x.Name,
                                       ProductsCount = x.CategoriesProducts.Count(),
                                       AveragePrice = $"{x.CategoriesProducts.Average(y => (decimal?)y.Product.Price):F2}",
                                       TotalRevenue = $"{x.CategoriesProducts.Sum(p => p.Product.Price):F2}",
                                   })
                                   .OrderByDescending(x => x.ProductsCount)
                                   .ToList();

            var parsedJson = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return parsedJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                                           .Where(x => x.ProductsSold.Any(ps => ps.BuyerId != null))
                                           .Select(x => new
                                           {
                                               FirstName = x.FirstName,
                                               LastName = x.LastName,
                                               Age = x.Age,
                                               SoldProducts = x.ProductsSold.Select(ps => new
                                               {
                                                   Count = x.ProductsSold.Where(p => p.BuyerId != null).Count(),
                                                   Products = x.ProductsSold.Where(p => p.BuyerId != null)
                                                                            .Select(sp => new
                                                                            {
                                                                                Name = sp.Name,
                                                                                Price = sp.Price.ToString("f2"),
                                                                            })

                                               })
                                               .ToList()
                                           })
                                           .OrderByDescending(x => x.SoldProducts.Count)
                                           .ToList();

            var finalUsers = new
            {
                UserCount = usersWithProducts.Count,
                Users = usersWithProducts,
            };

            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            var jsonSerializer = JsonConvert.SerializeObject(finalUsers, serializerSettings);
            return jsonSerializer;
        }
    }
}