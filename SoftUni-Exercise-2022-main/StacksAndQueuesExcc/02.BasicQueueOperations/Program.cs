using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elementsOperations = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int elementsToPush = elementsOperations[0];
            int elementsToPop = elementsOperations[1];
            int integerToFind = elementsOperations[2];
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count > 0)
            {
                if (queue.Contains(integerToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
