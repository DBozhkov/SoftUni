using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main()
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();
            int index = 0;

            for (int i = 0; i < pumpsCount; i++)
            {
                pumps.Enqueue(Console.ReadLine());
            }

            int counter = 0;

            for (int j = 0; j < pumps.Count; j++)
            {
                int totalFuel = 0;
                bool isComplete = true;

                for (int k = 0; k < pumps.Count; k++)
                {
                    string currPump = pumps.Dequeue();
                    int[] currValues = currPump.Split().Select(int.Parse).ToArray();

                    int fuel = currValues[0];
                    int distance = currValues[1];

                    totalFuel += fuel;

                    if (totalFuel >= distance)
                    {
                        totalFuel -= distance;
                    }
                    else
                    {
                        isComplete = false;
                    }
                    pumps.Enqueue(currPump);
                }
                if (isComplete)
                {
                    index = j;
                    break;
                }

                pumps.Enqueue(pumps.Dequeue());
            }
            Console.WriteLine(index);
        }
    }
}
