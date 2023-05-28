using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Func<string, int, bool> func = (name, nameLength) => name.Length <= nameLength;
            string[] names = Console.ReadLine().Split().Where(x => func(x, length)).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
