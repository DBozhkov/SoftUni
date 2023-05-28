using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, int, bool> func = (a, b) => a % b == 0;
            List<int> final = new List<int>();

            bool isDivisible = false;
            for (int i = 1; i <= endRange; i++)
            {
                foreach (var num in numbers)
                {
                    if (func(i, num))
                    {
                        isDivisible = true;
                    }
                    else
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible == true)
                {
                    final.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", final));
        }
    }
}
