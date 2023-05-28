using System;
using System.Collections.Generic;

namespace _06.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] arr = input.Split();

                if (arr.Length == 3)
                {
                    buyers.Add(arr[0], new Rebel(arr[0], int.Parse(arr[1]), arr[2]));
                }

                else if (arr.Length == 4)
                {
                    buyers.Add(arr[0], new Citizen(arr[0], int.Parse(arr[1]), arr[2], arr[3]));
                }
            }
            int finalFood = 0;
            string name = Console.ReadLine();
            while (name != "End")
            {
                if (!buyers.ContainsKey(name))
                {
                    name = Console.ReadLine();
                    continue;
                }
                else
                {
                    buyers[name].BuyFood();
                }
                name = Console.ReadLine();
            }

            foreach (var buyer in buyers.Values)
            {
                finalFood += buyer.Food;
            }

            Console.WriteLine(finalFood);
        }
    }
}
