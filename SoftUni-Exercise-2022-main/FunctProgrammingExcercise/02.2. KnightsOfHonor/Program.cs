using System;

namespace _02._2._KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            Action<string[]> act = WriteArray;
            act(arr);
        }

        static void WriteArray(string[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine($"Sir {item}");
            }
        }
    }
}
