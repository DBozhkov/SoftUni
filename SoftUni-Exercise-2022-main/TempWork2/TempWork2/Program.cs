using System;
using System.Collections.Generic;
using System.Linq;

namespace TempWork2
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Product> productList = new Dictionary<string, Product>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "buy")
                {
                    break;
                }

                string[] words = input.Split();
                string name = words[0];
                double price = double.Parse(words[1]);
                int quantity = int.Parse(words[2]);

                Product product = new Product(name, price, quantity);

                if (!productList.ContainsKey(name))
                {
                    productList.Add(name, product);
                }
                else
                {
                    productList[name].Price = price;
                    productList[name].Quantity += quantity;
                }
            }

            foreach (var pair in productList)
            {
                Console.WriteLine($"{pair.Key} -> {(1.0 * pair.Value.Price) * pair.Value.Quantity:f2}");
            }
        }
    }

    public class Product
    {
        public string name;
        public double price;
        public int quantity;

        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
    }
}

