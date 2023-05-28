using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(clothes);
            int tempRack = rackCapacity;
            int rackCounter = 1;

            while (stack.Count > 0)
            {
                if (stack.Peek() <= rackCapacity)
                {
                    rackCapacity -= stack.Pop();
                }
                else
                {
                    rackCapacity = tempRack;
                    rackCounter++;
                }
            }
            Console.WriteLine(rackCounter);
        }
    }
}
