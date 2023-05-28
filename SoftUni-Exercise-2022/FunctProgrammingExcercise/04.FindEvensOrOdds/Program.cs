using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int lower = arr[0];
            int higher = arr[1];

            string type = Console.ReadLine();
            Predicate<int> prd = x => x % 2 == 0;
            List<int> finalList = new List<int>();

            if (type == "even")
            {
                for (int i = lower; i <= higher; i++)
                {
                    if (prd(i))
                    {
                        finalList.Add(i);
                    }
                }
            }

            else if (type == "odd")
            {
                for (int i = lower; i <= higher; i++)
                {
                    if (!prd(i))
                    {
                        finalList.Add(i);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
