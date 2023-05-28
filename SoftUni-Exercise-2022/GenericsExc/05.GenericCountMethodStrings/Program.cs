using System;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.AddItems(input);
            }

            string comparer = Console.ReadLine();
            Console.WriteLine(box.Compare(comparer));
        }
    }
}
