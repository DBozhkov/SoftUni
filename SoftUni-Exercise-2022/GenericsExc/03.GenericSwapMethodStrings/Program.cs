using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();
                box.AddItems(input);
            }
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            box.Swap(list);

            Console.WriteLine(box);
        }
    }
}
