using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           HashSet<string> set = new HashSet<string>();
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                queue.Enqueue(input);
            }
            foreach (var item in queue)
            {
                set.Add(item);
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
