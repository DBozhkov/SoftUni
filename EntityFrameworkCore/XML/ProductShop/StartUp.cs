using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        private static readonly string usersLocation = @"../../../Datasets/users.xml";
        private static readonly string productsLocation = @"../../../Datasets/products.xml";
        private static readonly string categoriesLocation = @"../../../Datasets/categories.xml";
        private static readonly string categoriesProductsLocation = @"../../../Datasets/categories-products.xml";

        public static void Main()
        {
            var context = new ProductShopContext();
            //DatabaseReset(context);


            File.WriteAllText(@"../../../Datasets/categories-by-products.xml", GetCategoriesByProductsCount(context));
        }

        //public static void DatabaseReset(ProductShopContext context)
        //{
        //    context.Database.EnsureDeleted();
        //    Console.WriteLine("Database deleted!!!");

        //    context.Database.EnsureCreated();
        //    Console.WriteLine("Database created!!!");
        //}

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(UsersImportDto[]), new XmlRootAttribute("Users"));

            var users = (UsersImportDto[])xmlSerializer.Deserialize(File.OpenRead(inputXml));

            var finalUsers = users.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
            })
            .ToList();

            context.Users.AddRange(finalUsers);
            context.SaveChanges();
            return $"Successfully imported {finalUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ProductsImportDto[]), new XmlRootAttribute("Products"));


            var products = (ProductsImportDto[])xmlSerializer.Deserialize(File.OpenRead(inputXml));

            var finalProducts = products.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                SellerId = x.SellerId,
                BuyerId = x.BuyerId,
            })
            .ToList();

            context.Products.AddRange(finalProducts);
            context.SaveChanges();
            return $"Successfully imported {finalProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoriesImportDto[]), new XmlRootAttribute("Categories"));

            var categories = (CategoriesImportDto[])xmlSerializer.Deserialize(File.OpenRead(inputXml));

            var finalCategories = categories.Where(x => x.Name != null).Select(x => new Category
            {
                Name = x.Name,
            })
            .ToList();

            context.Categories.AddRange(finalCategories);
            context.SaveChanges();
            return $"Successfully imported {finalCategories.Count}";

            //var serializer = new XmlSerializer(typeof(List<CategoriesImportDto>), new XmlRootAttribute("Categories"));

            //var categoriesDtos = (List<CategoriesImportDto>)serializer.Deserialize(new StringReader(inputXml));

            //List<Category> categories = new List<Category>();
            //// judge no like map
            ////var categories = Mapper.Map<List<Category>>(categoriesDtos)
            ////    .Where(c => c.Name != null)
            ////    .ToList();
            //foreach (var categoriesDto in categoriesDtos)
            //{
            //    Category category = new Category()
            //    {
            //        Name = categoriesDto.Name
            //    };
            //    if (category.Name != null) // in the xml none of them are null but ok
            //    {
            //        categories.Add(category);
            //    }
            //}

            //context.Categories.AddRange(categories);

            //context.SaveChanges();

            //return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CategoryProductImportDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesProducts = (CategoryProductImportDto[])xmlSerializer.Deserialize(File.OpenRead(inputXml));

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProducts)
            {
                if (context.Categories.Any(c => c.Id == categoryProductDto.CategoryId) &&
                    context.Products.Any(p => p.Id == categoryProductDto.ProductId))
                {
                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryProductDto.CategoryId,
                        ProductId = categoryProductDto.ProductId,
                    };
                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";

        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsRange = context.Products
                                       .Where(p => p.Price >= 500 && p.Price <= 1000)
                                       .Select(x => new ExportProductsRangeDto
                                       {
                                           Name = x.Name,
                                           Price = x.Price,
                                           Buyer = $"{x.Buyer.FirstName} {x.Buyer.LastName}",
                                       })
                                       .OrderBy(x => x.Price)
                                       .Take(10)
                                       .ToList();

            var xmlSerializer = new XmlSerializer(typeof(List<ExportProductsRangeDto>), new XmlRootAttribute("Products"));

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, productsRange);
                return textWriter.ToString();
            }
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersSoldProducts = context.Users
                                       .Where(u => u.ProductsSold.Any())
                                       .Select(x => new ExportUsersSoldProducts
                                       {
                                           FirstName = x.FirstName,
                                           LastName = x.LastName,
                                           SoldProducts = x.ProductsSold
                                                           .Where(p => p.Buyer != null)
                                                           .Select(y => new SoldProducts
                                                           {
                                                               Name = y.Name,
                                                               Price = y.Price,
                                                           })
                                                           .ToList()
                                       })
                                       .OrderBy(x => x.LastName)
                                       .ThenBy(x => x.FirstName)
                                       .Take(5)
                                       .ToList();

            var xmlSerializer = new XmlSerializer(typeof(List<ExportUsersSoldProducts>), new XmlRootAttribute("Users"));

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, usersSoldProducts);
                return textWriter.ToString();
            }
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
               .Categories
               .Select(x => new ExportCategoryByProductsDto()
               {
                   Name = x.Name,
                   AveragePrice = x.CategoryProducts.Average(s => s.Product.Price),
                   ProductsCount = x.CategoryProducts.Count,
                   TotalRevenue = x.CategoryProducts.Sum(s => s.Product.Price)
               })
               .OrderByDescending(c => c.ProductsCount)
               .ThenBy(c => c.TotalRevenue)
               .ToList();

            var xmlSerializer = new XmlSerializer(typeof(List<ExportCategoryByProductsDto>), new XmlRootAttribute("Categories"));

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, categories);
                return textWriter.ToString();
            }
        }
    }
}