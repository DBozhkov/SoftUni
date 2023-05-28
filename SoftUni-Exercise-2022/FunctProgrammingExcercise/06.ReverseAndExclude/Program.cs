using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> func = x =>
            {
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i] % n == 0)
                    {
                        x.Remove(x[i]);
                        i--;
                    }
                }
                return x;
            };

            func(list).Reverse();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
