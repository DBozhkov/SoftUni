using System;
using System.Collections.Generic;

namespace _02.GenericBoxOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            var list = new List<Box<int>>();

            for (int i = 0; i < counter; i++)
            {
                int input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
