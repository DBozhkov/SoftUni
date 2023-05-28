using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main()
        {
            int counter = int.Parse(Console.ReadLine());
            int[] array1 = new int[counter];
            int[] array2 = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                int[] current = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    array1[i] = current[0];
                    array2[i] = current[1];
                }
                else
                {
                    array2[i] = current[0];
                    array1[i] = current[1];
                }

            }

            Console.WriteLine(string.Join(' ', array1));
            Console.WriteLine(string.Join(' ', array2));

        }
    }
}
