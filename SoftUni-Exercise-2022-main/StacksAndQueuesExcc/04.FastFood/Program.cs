using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int orderQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            int biggestOrder = orders.Max();
            int sum = 0;

            for (int i = 0; i < orders.Length; i++)
            {
                sum += orders[i];
                if (sum <= orderQuantity)
                {
                    queue.Dequeue();
                }
            }
            Console.WriteLine(biggestOrder);
            if (queue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
