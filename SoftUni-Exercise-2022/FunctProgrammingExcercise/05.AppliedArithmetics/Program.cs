using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<List<int>, List<int>> func = x => x;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        list = func(Add(list));
                        break;
                    case "multiply":
                        list = func(Multiply(list));
                        break;
                    case "subtract":
                        list = func(Subtract(list));
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", list));
                        break;
                }
            }
        }

        static List<int> Add(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] += 1;
            }
            return list;
        }

        static List<int> Multiply(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] *= 2;
            }
            return list;
        }

        static List<int> Subtract(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] -= 1;
            }
            return list;
        }
    }
}
