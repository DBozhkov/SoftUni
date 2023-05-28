using System;
using System.Collections.Generic;

namespace _01.GenericBoxOfString
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            var list = new List<Box<string>>();

            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();
                var box = new Box<string>(input);
                Console.WriteLine(box.ToString());
            }
        }


    }
}
