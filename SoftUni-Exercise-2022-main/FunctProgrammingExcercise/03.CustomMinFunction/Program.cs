using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> func = x => arr.Min();
            
            Console.WriteLine(func(arr));
        }
    }
}
