using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = arr[0];
            int m = arr[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int c = int.Parse(Console.ReadLine());
                firstSet.Add(c);
            }

            for (int j = 0; j < m; j++)
            {
                int d = int.Parse(Console.ReadLine());
                secondSet.Add(d);
            }

            List<int> list = new List<int>();
            foreach (var firstNum in firstSet)
            {
                foreach (var secondNum in secondSet)
                {
                    if (firstNum == secondNum)
                    {
                        list.Add(firstNum);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
