using System;

namespace _06.GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.AddItems(input);
            }

            double comparer = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Compare(comparer));
        }
    }
}
