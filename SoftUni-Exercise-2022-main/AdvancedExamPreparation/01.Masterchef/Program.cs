using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingredientsCount = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] ingredientsFreshness = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var dict = new Dictionary<string, int>()
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0},
                { "Chocolate cake", 0},
                { "Lobster", 0},
            };

            Queue<int> ingredientValue = new Queue<int>(ingredientsCount);
            Stack<int> freshnessValue = new Stack<int>(ingredientsFreshness);

            

            while (ingredientValue.Any() || freshnessValue.Any())
            {
                int totalFreshness = 0;
                if (ingredientValue.Count <= 0 || freshnessValue.Count <= 0)
                {
                    break;
                }
                if (ingredientValue.Peek() == 0)
                {
                    ingredientValue.Dequeue();
                    continue;
                }

                totalFreshness += ingredientValue.Peek() * freshnessValue.Peek();
                if (totalFreshness == 150 )
                {
                    dict["Dipping sauce"]++;
                    totalFreshness = 0;
                    ingredientValue.Dequeue();
                    freshnessValue.Pop();
                }

                else if (totalFreshness == 250)
                {
                    dict["Green salad"]++;
                    totalFreshness = 0;
                    ingredientValue.Dequeue();
                    freshnessValue.Pop();
                }

                else if (totalFreshness == 300)
                {
                    dict["Chocolate cake"]++;
                    totalFreshness = 0;
                    ingredientValue.Dequeue();
                    freshnessValue.Pop();
                }

                else if (totalFreshness == 400)
                {
                    dict["Lobster"]++;
                    totalFreshness = 0;
                    ingredientValue.Dequeue();
                    freshnessValue.Pop();
                }

                else
                {
                    freshnessValue.Pop();
                    int temp = ingredientValue.Dequeue() + 5;
                    ingredientValue.Enqueue(temp);
                }
            }

            int keysCount = 0;
            foreach (var key in dict)
            {
                if (key.Value > 0)
                {
                    keysCount++;
                }
            }

            if (keysCount < 4)
            {
                Console.WriteLine("You were voted off. Better luck next year.");        
            }
            else if (keysCount == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }

            if (ingredientValue.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredientValue.Sum()}");
            }

            foreach (var product in dict.OrderBy(x => x.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($" # {product.Key} --> {product.Value}");
                }
            }
        }
    }
}
