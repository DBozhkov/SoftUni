using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] splitter = new string[] { " -> " };
                List<string> list = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList();

                string colour = list[0];
                string[] items = list[1].Split(',');

                if (!dict.ContainsKey(colour))
                {
                    dict.Add(colour, new Dictionary<string, int>());
                    for (int j = 0; j < items.Length; j++)
                    {
                        string item = items[j];
                        if (!dict[colour].ContainsKey(item))
                        {
                            dict[colour].Add(item, 1);
                        }
                        else
                        {
                            dict[colour][item]++;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < items.Length; j++)
                    {
                        string item = items[j];
                        if (!dict[colour].ContainsKey(item))
                        {
                            dict[colour].Add(item, 1);
                        }
                        else
                        {
                            dict[colour][item]++;
                        }
                    }
                }
            }
            string[] itemToFind = Console.ReadLine().Split();


            foreach (var colour in dict)
            {
                bool isValid = false;
                if (colour.Key == itemToFind[0])
                {
                    isValid = true;
                }
                Console.WriteLine($"{colour.Key} clothes:");
                foreach (var item in colour.Value)
                {
                    if (item.Key == itemToFind[1] && isValid == true)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {item.Key} - {item.Value}");
                }
            }
        }
    }
}
