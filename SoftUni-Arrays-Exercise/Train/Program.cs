using System;

namespace Train
{
    class Program
    {
        static void Main()
        {
            int counter = int.Parse(Console.ReadLine());
            int[] wagons = new int[counter];

            int sum = 0;

            for (int i = 0; i < counter; i++)
            {
                int wagonsCount = int.Parse(Console.ReadLine());
                wagons[i] = wagonsCount;
                sum += wagonsCount;

            }

            Console.WriteLine(string.Join(' ', wagons));
            Console.WriteLine(sum);
        }
    }
}
