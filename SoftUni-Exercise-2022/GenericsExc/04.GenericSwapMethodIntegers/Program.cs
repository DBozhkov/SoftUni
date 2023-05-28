using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < counter; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.AddItems(input);
            }
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            box.Swap(list);

            Console.WriteLine(box);
        }
    }
}
