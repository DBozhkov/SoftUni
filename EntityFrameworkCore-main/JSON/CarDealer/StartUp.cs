using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        private static readonly string suppliersInput = @"../../../Datasets/suppliers.json";
        private static readonly string partsInput = @"../../../Datasets/parts.json";
        private static readonly string carsInput = @"../../../Datasets/cars.json";
        private static readonly string customersInput = @"../../../Datasets/customers.json";
        private static readonly string salesInput = @"../../../Datasets/sales.json";

        public static void Main()
        {
            var context = new CarDealerContext();

            //string jsonSuppliers = File.ReadAllText(suppliersInput);
            //string jsonParts = File.ReadAllText(partsInput);
            //string jsonCars = File.ReadAllText(carsInput);
            //string jsonCustomers = File.ReadAllText(customersInput);
            //string jsonSales = File.ReadAllText(salesInput);

            //ResetDatabase(context);

            ////Import Data
            //Console.WriteLine(ImportSuppliers(context, jsonSuppliers));
            //Console.WriteLine(ImportParts(context, jsonParts));
            //Console.WriteLine(ImportCars(context, jsonCars));
            //Console.WriteLine(ImportCustomers(context, jsonCustomers));
            //Console.WriteLine(ImportSales(context, jsonSales));

            //Write Date

            File.WriteAllText(@"../../../Datasets/sales-discounts.json", GetSalesWithAppliedDiscount(context));
        }

        //public static void ResetDatabase(CarDealerContext context)
        //{
        //    context.Database.EnsureDeleted();
        //    context.Database.EnsureCreated();
        //}

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();
            var importedParts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                                           .Where(x => supplierIds.Contains(x.SupplierId));

            context.Parts.AddRange(importedParts);
            context.SaveChanges();

            return $"Successfully imported {importedParts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context.Customers
                                          .Select(x => new
                                          {
                                              Name = x.Name,
                                              BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                                              IsYoungDriver = x.IsYoungDriver,
                                          })
                                          .OrderBy(x => x.BirthDate)
                                          .ThenBy(x => x.IsYoungDriver == false)
                                          .ToList();

            var serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            var exportJson = JsonConvert.SerializeObject(orderedCustomers, serializerSettings);
            return exportJson;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                                    .Where(c => c.Make == "Toyota")
                                    .Select(x => new
                                    {
                                        Id = x.Id,
                                        Make = x.Make,
                                        Model = x.Model,
                                        TraveledDistance = x.TraveledDistance,
                                    })
                                    .OrderBy(x => x.Model)
                                    .ThenByDescending(x => x.TraveledDistance)
                                    .ToList();

            var exportJson = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            return exportJson;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                                        .Where(x => !x.IsImporter)
                                        .Select(x => new
                                        {
                                            Id = x.Id,
                                            Name = x.Name,
                                            PartsCount = x.Parts.Count(),
                                        })
                                        .ToList();

            var exportJson = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            return exportJson;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carAndParts = context.Cars
                                     .Select(x => new
                                     {
                                         car = new
                                         {
                                             Make = x.Make,
                                             Model = x.Model,
                                             TraveledDistance = x.TraveledDistance,
                                         },
                                         parts = x.PartsCars.Select(pc => new
                                         {
                                             Name = pc.Part.Name,
                                             Price = pc.Part.Price.ToString("f2"),
                                         })
                                     })
                                     .ToList();

            var exportJson = JsonConvert.SerializeObject(carAndParts, Formatting.Indented);
            return exportJson;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var salesCustomers = context.Sales
                .Where(x => x.Customer.Sales.Any())
                .Select(x => new
                {
                    FullName = x.Customer.Name,
                    BoughtCars = x.Customer.Sales.Count(),
                    SpentMoney = x.Customer.Sales.Sum(y => y.Car.PartsCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .Distinct()
                .ToArray();

            var exportJson = JsonConvert.SerializeObject(salesCustomers, Formatting.Indented);
            return exportJson;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TraveledDistance
                },
                customerName = s.Customer.Name,
                Discount = s.Discount.ToString("f2"),
                price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                priceWithDiscount = ((s.Car.PartsCars.Sum(pc => pc.Part.Price)) * (1 - s.Discount * 0.01m))
                .ToString("f2")
            }).Take(10).ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}